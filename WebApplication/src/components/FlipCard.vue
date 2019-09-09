<template>
  <section
    class="card-container"
    :style="{ width, height, perspective: '800px' }"
  >
    <div
      class="flip-card"
      :class="{ flipped }"
      :style="{ transition: 'transform 1s' }"
    >
      <figure class="front-card">
        <slot name="front"></slot>
      </figure>
      <figure class="back-card" :style="backStyle">
        <slot name="back"></slot>
      </figure>
    </div>
  </section>
</template>
<script>
import { getContext } from "../infra/browserContext";

const props = {
  flipped: {
    required: false,
    default: false
  },
  width: {
    required: true,
    type: String
  },
  height: {
    required: true,
    type: String
  }
};
export default {
  name: "flip-card",
  props,
  data: () => ({
    firstFlip: true,
    forceBackface: false
  }),
  computed: {
    backStyle() {
      return this.forceBackface ? { "backface-visibility": "visible" } : null;
    }
  },
  created() {
    const { setTimeout, clearTimeout } = window;
    const updateBackface = (value, time = 1, callBack = null) =>
      setTimeout(() => {
        this.forceBackface = value;
        callBack && callBack();
      }, 1000 * time);

    const setFlipWatcher = watcher => this.$watch("flipped", watcher);
    const context = getContext();
    let handle = null;
    switch (context) {
      case "chrome":
        setFlipWatcher(value => {
          const { firstFlip } = this;
          if (!value || !firstFlip) {
            return;
          }
          this.firstFlip = false;
          this.forceBackface = true;
          updateBackface(false);
        });
        break;

      case "IE11":
        setFlipWatcher(value => {
          if (handle) {
            clearTimeout(handle);
            handle = null;
            return;
          }
          handle = updateBackface(value, 0.3, () => (handle = null));
        });
        break;
    }
  }
};
</script>
<style scoped>
.card-container {
  position: relative;
  margin: 5px;
}
.flip-card {
  width: 100%;
  height: 100%;
  position: absolute;
  transform-style: preserve-3d;
}
.flip-card figure {
  margin: 0;
  position: absolute;
  width: 100%;
  height: 100%;
  transform: translate3d(0, 0, 0);
  backface-visibility: hidden;
}
.flip-card .back-card {
  transform: rotateY(180deg);
}
.flip-card.flipped {
  transform: rotateY(180deg);
}
</style>
