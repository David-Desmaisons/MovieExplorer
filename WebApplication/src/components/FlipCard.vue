<template>
  <section
    class="card-container"
    :style="{ width, height, perspective: perspective + 'px' }"
  >
    <div
      class="flip-card"
      :class="{ flipped }"
      :style="{ transition: 'transform ' + transition + 's' }"
    >
      <figure class="front-card">
        <slot name="front"> </slot>
      </figure>
      <figure class="back-card" :style="backStyle">
        <slot name="back"> </slot>
      </figure>
    </div>
  </section>
</template>
<script>
const props = {
  flipped: {
    required: false,
    default: false
  },
  width: {
    required: false,
    type: String,
    default: "150px"
  },
  height: {
    required: false,
    type: String,
    default: "150px"
  },
  perspective: {
    required: false,
    type: Number,
    default: 800
  },
  transition: {
    required: false,
    type: Number,
    default: 1
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
  watch: {
    flipped(value) {
      //Chrome CSS fix
      const { transition, firstFlip } = this;
      if (!value || !firstFlip) {
        return;
      }
      this.firstFlip = false;
      const update = (force, time) =>
        window.setTimeout(() => {
          this.forceBackface = force;
        }, time);

      update(true, transition * 300);
      update(false, transition * 1000);
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
