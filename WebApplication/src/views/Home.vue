<template>
  <v-content>
    <v-container fluid class="main-container">
      <v-flex
        lg10
        offset-lg1
        row
        wrap
        xs12
        class="mt-5 mb-5 movie-item-container"
      >
        <v-overlay :value="firstload">
          <v-progress-circular indeterminate size="64"></v-progress-circular>
        </v-overlay>

        <MovieCard
          :class="{ 'last-movie-visible': true }"
          v-for="movie in moviesToDisplay"
          :key="movie.id"
          :movie="movie"
        />
        
      </v-flex>
    </v-container>
  </v-content>
</template>
<script>
import MovieCard from "../components/MovieCard";
import ScrollWatch from "scrollwatch";
import { mapState, mapMutations } from "vuex";
import debounce from "lodash.debounce";

function mapMovie(movie) {
  return {
    ...movie,
    titleForSearch: movie.title.toLowerCase()
  };
}

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
    firstload: true,
    searchValue: ""
  }),
  async created() {
    this.$store.dispatch("displaySearch");
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
    ...mapMutations(["updateLoading"]),
    async loadNextPage() {
      const { loadedAll, loading, pageLoaded } = this;
      if (loadedAll || loading) {
        return;
      }
      this.updateLoading(!this.firstload);
      this.loading = true;
      const nextPage = pageLoaded + 1;
      const result = await this.$get(`Movies?start=${nextPage}`);
      this.onLoaded(result, nextPage);
    },
    onLoaded({ results, total_results }, nextPage) {
      const { movies } = this;
      const updatedMovies = results.map(mapMovie);
      movies.push(...updatedMovies);
      this.pageLoaded = nextPage;
      this.loadedAll = total_results === movies.length;
      this.firstload = false;
      this.loading = false;
      this.updateLoading(false);
    },
    updateSearch: debounce(function(value) {
      this.searchValue = value.toLowerCase();
    }, 200)
  },
  computed: {
    ...mapState(["searchInformation"]),
    moviesToDisplay() {
      const { searchValue, movies } = this;
      return searchValue === ""
        ? movies
        : movies.filter(movie => movie.titleForSearch.includes(searchValue));
    }
  },
  watch: {
    searchInformation(value) {
      this.updateSearch(value);
    }
  }
};
</script>
