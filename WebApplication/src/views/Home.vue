<template>
  <v-content>
    <v-container fluid class="main-container">
      <v-flex lg10 offset-lg1 row wrap>
        <v-overlay :value="firstload">
          <v-progress-circular indeterminate size="64"></v-progress-circular>
        </v-overlay>

        <MovieCard v-for="movie in movies" :key="movie.id" :movie="movie" />
      </v-flex>
    </v-container>
  </v-content>
</template>
<script>
import { buildUrl } from "../infra/urlBuilder";
import MovieCard from "../components/MovieCard";

export default {
  name: "home",
  components: {
    MovieCard
  },
  data: () => ({
    loading: false,
    movies: [],
    pageLoaded: 0,
    loadedAll: false,
    firstload: true
  }),
  async created() {
    await this.loadNextPage();
  },
  methods: {
    async loadNextPage() {
      const { loadedAll, pageLoaded, movies } = this;
      if (loadedAll) {
        return;
      }
      const nextPage = pageLoaded + 1;
      const res = await this.$get(`?start=${nextPage}`);
      const resultWithLink = res.results.map(movie => ({
        ...movie,
        poster_url: buildUrl(movie.poster_path, "w500")
      }));
      movies.push(...resultWithLink);
      this.pageLoaded = nextPage;
      this.loadedAll = res.total_results === movies.length;
      this.firstload = false;
    }
  }
};
</script>
