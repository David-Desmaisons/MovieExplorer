<template>
  <v-card class="information">
    <v-card-title class="normal">{{ movie.title }}</v-card-title>
    <v-card-text>{{ movie.release_date }}</v-card-text>
    <v-spacer></v-spacer>
    <v-divider></v-divider>
    <v-rating
      :value="movie.vote_average / 2"
      readonly
      small
      color="yellow"
      background-color="grey lighten-1"
    ></v-rating>
    <v-card-actions>
      <v-btn class="mx-2" fab dark small color="primary" :to="detailRoute">
        <v-icon dark>mdi-alert-circle</v-icon>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
export default {
  name: "movie-information",
  props: {
    movie: {
      required: true,
      type: Object
    }
  },
  computed: {
    detailRoute() {
      const {
        movie: { id }
      } = this;
      return {
        name: "movie",
        params: { id: `${id}` }
      };
    }
  }
};
</script>
<style lang="less" scoped>
div.normal {
  word-break: normal;
}
</style>
