<template>
  <v-card>
    <v-row class="py-4 pl-4 mb-6">
      <v-col cols="sm" :sm="12" :md="6">
        <v-img v-if="posterUrl" aspect-ratio="1" contain :src="posterUrl">
          <template #placeholder>
            <div class="place-holder" />
          </template>
        </v-img>
        <v-row v-else class="place-holder pa-4">
          <h1>No image</h1>
        </v-row>
      </v-col>
      <v-col
        cols="sm"
        :sm="12"
        :md="4"
        :offset-sm="0"
        :offset-md="0"
        class="ma-1"
      >
        <v-container>
          <v-row>
            <h1>{{ movie.title }}</h1>
          </v-row>
          <v-row>
            <p>{{ genres }}</p>
          </v-row>
          <v-row>
            <p>Release date: {{ releaseDate }}</p>
          </v-row>
          <v-row>
            <MovieRating :vote="movie.vote_average" />
          </v-row>
          <v-divider></v-divider>
          <v-row>
            <p class="overview text-justify">{{ movie.overview }}</p>
          </v-row>
          <v-row>
            <v-card-actions>
              <v-tooltip bottom>
                <template v-slot:activator="{ on }">
                  <v-btn
                    class="mx-2"
                    fab
                    dark
                    small
                    color="primary"
                    :to="{ name: 'home' }"
                    v-on="on"
                  >
                    <v-icon dark>mdi-movie-roll</v-icon>
                  </v-btn>
                </template>
                <span class="caption">To home</span>
              </v-tooltip>

              <v-tooltip bottom v-if="movie.homepage">
                <template v-slot:activator="{ on }">
                  <v-btn
                    class="mx-2"
                    fab
                    dark
                    small
                    color="secondary"
                    :href="movie.homepage"
                    v-on="on"
                  >
                    <v-icon dark>mdi-link</v-icon>
                  </v-btn>
                </template>
                <span class="caption">To movie homepage</span>
              </v-tooltip>
            </v-card-actions>
          </v-row>
        </v-container>
      </v-col>
    </v-row>
  </v-card>
</template>
<script>
import MovieRating from "./MovieRating";

export default {
  name: "movie-detail",
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
    posterUrl() {
      return this.movie.poster_path;
    },
    genres() {
      return this.movie.genres.map(m => m.name).join(", ");
    },
    releaseDate() {
      const date = new Date(this.movie.release_date);
      return date.toDateString();
    }
  }
};
</script>
<style lang="less" scoped>
.place-holder {
  background: lightgray;
  height: 750px;
  margin: 0px 130px 0px 120px;
  h1 {
    vertical-align: middle;
  }
}

.overview {
  padding: 0 10px 10px 0;
}
</style>
