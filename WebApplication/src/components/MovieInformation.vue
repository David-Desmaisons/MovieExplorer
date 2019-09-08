<template>
  <v-card class="information">
    <v-card-title class="normal">{{ movie.title }}</v-card-title>
    <v-card-text>{{ movie.release_date }}</v-card-text>
    <v-spacer></v-spacer>
    <v-divider></v-divider>
    <MovieRating :vote="movie.vote_average" />
    <v-card-actions>
      <v-tooltip bottom>
        <template v-slot:activator="{ on }">
          <v-btn
            class="mx-2"
            fab
            dark
            small
            color="primary"
            :to="detailRoute"
            v-on="on"
          >
            <v-icon dark>mdi-alert-circle</v-icon>
          </v-btn>
        </template>
        <span class="caption">Detail</span>
      </v-tooltip>
    </v-card-actions>
  </v-card>
</template>
<script>
import MovieRating from "./MovieRating";
export default {
  name: "movie-information",
  components: {
    MovieRating
  },
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
