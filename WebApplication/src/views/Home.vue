<template>
  <v-content>
    <v-container fluid class="main-container">
      <v-flex lg10 offset-lg1 row wrap class="movie-item-container">
        <v-overlay :value="firstload">
          <v-progress-circular indeterminate size="64"></v-progress-circular>
        </v-overlay>

        <MovieCard
          :class="{ 'last-movie-visible': true }"
          v-for="movie in movies"
          :key="movie.id"
          :movie="movie"
        />
      </v-flex>
    </v-container>
  </v-content>
</template>
<script>
import { buildUrl } from "../infra/urlBuilder";
import MovieCard from "../components/MovieCard";
import ScrollWatch from "scrollwatch";

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
  mounted() {
    var watch = new ScrollWatch({
      infiniteScroll: true,
      watch: "section",
      infiniteOffset: 200,
      onInfiniteYInView: () => this.loadNextPage()
    });
    this.$once("hook:destroy", () => {
      watch.destroy();
    });
    this.$on("hook:updated", () => {
      watch.refresh();
    });
  },
  methods: {
    async loadNextPage() {
      const { loadedAll, loading, pageLoaded, movies } = this;
      if (loadedAll || loading) {
        return;
      }
      this.loading = true;
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
      this.loading = false;
    }
  }
};
</script>
