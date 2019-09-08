<template>
<section class="card-container" :style="{width, height, perspective: perspective+'px'}">
  <div class="flip-card" :class="{flipped}" :style="{transition: 'transform '+transition+'s'}">
    <figure class="front">
        <slot name="front">
        </slot> 
    </figure>
    <figure class="back-card">
        <slot name="back">
        </slot>
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
  props
};
</script>
<style scoped>
.card-container {
  position: relative;
}
.flip-card {
  width: 100%;
  height: 100%;
  position: absolute;
  transform-style: preserve-3d;
}
.flip-card figure {
  margin: 0;
  display: block;
  position: absolute;
  width: 100%;
  height: 100%;
  /* backface-visibility: hidden; */
}
.flip-card .back-card {
  transform: rotateY(180deg);
}
.flip-card.flipped {
  transform: rotateY(180deg);
}
</style>
