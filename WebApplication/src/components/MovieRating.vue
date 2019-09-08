<template>
  <v-rating
    :value="vote / 2"
    readonly
    small
    color="yellow"
    background-color="grey lighten-1"
  ></v-rating>
</template>
<script>
export default {
  name: "movie-rating",
  props: {
    vote: {
      type: Number,
      required: true
    }
  }
};
</script>
