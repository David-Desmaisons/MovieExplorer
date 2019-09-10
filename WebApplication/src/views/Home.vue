<template>
  <v-flex lg10 offset-lg1 row wrap xs12 class="mt-5 mb-5 movie-item-container">
    <v-overlay :value="firstload">
      <v-progress-circular indeterminate size="64"></v-progress-circular>
    </v-overlay>

    <v-card lg12 v-if="nothingFound">
      <v-card-title>
        <p>
          Your search:
          <span class="red--text">{{ searchValue }}</span> did not match any
          movie
        </p>
      </v-card-title>
    </v-card>

    <MovieCard
      v-for="movie in moviesToDisplay"
      :key="movie.id"
      :movie="movie"
    />
  </v-flex>
</template>
<script>
import MovieCard from "../components/MovieCard";
import ScrollWatch from "scrollwatch";
import { mapState, mapActions, mapMutations } from "vuex";
import debounce from "lodash.debounce";

const pageLength = 20;

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
    maxDisplay: pageLength,
    searchValue: ""
  }),
  async created() {
    this.$store.dispatch("displaySearch");
    try {
      await this.$store.dispatch("loadGenres");
      await this.loadNextPage();
    } catch (error) {
      this.onLoadError(error);
    }
  },
  mounted() {
    var watch = new ScrollWatch({
      infiniteScroll: true,
      watch: "section",
      infiniteOffset: 200,
      onInfiniteYInView: () => {
        const newDisplay = this.maxDisplay + pageLength;
        this.maxDisplay = newDisplay;
        if (this.allMoviesToDisplay.length >= newDisplay) {
          return;
        }
        this.loadNextPage();
      }
    });
    this.$once("hook:destroy", () => {
      watch.destroy();
    });
  },
  methods: {
    ...mapMutations(["updateLoading"]),
    ...mapActions(["displayError"]),
    async loadNextPage() {
      const { loadedAll, loading, pageLoaded } = this;
      if (loadedAll || loading) {
        return;
      }
      this.updateLoading(!this.firstload);
      this.loading = true;
      const nextPage = pageLoaded + 1;
      try {
        const result = await this.$get(`Movies?start=${nextPage}`);
        this.onLoadSuccess(result, nextPage);
      } catch (error) {
        this.onLoadError(error);
      }
    },
    onLoadSuccess({ results, total_results }, nextPage) {
      const updatedMovies = results.map(mapMovie);
      const { movies } = this;
      movies.push(...updatedMovies);
      this.pageLoaded = nextPage;
      this.loadedAll = total_results === movies.length;
      this.loadEnded();
    },
    onLoadError() {
      this.displayError("Connection problem with server");
      this.loadEnded();
    },
    loadEnded() {
      this.firstload = false;
      this.loading = false;
      this.updateLoading(false);
    },
    updateSearch: debounce(function(value) {
      this.searchValue = value.toLowerCase();
      this.maxDisplay = pageLength;
    }, 250)
  },
  computed: {
    ...mapState(["searchInformation"]),
    nothingFound() {
      return (
        this.loadedAll &&
        this.searchValue !== "" &&
        this.moviesToDisplay.length === 0
      );
    },
    allMoviesToDisplay() {
      const { searchValue, movies } = this;
      return searchValue === ""
        ? movies
        : movies.filter(movie => movie.titleForSearch.includes(searchValue));
    },
    moviesToDisplay() {
      const { allMoviesToDisplay, maxDisplay } = this;
      return allMoviesToDisplay.slice(0, maxDisplay);
    }
  },
  watch: {
    searchInformation(value) {
      this.updateSearch(value);
    },
    async allMoviesToDisplay(value) {
      if (value.length < pageLength) {
        await this.loadNextPage();
      }
    }
  }
};
</script>
<style lang="less">
.movie-item-container {
  width: 100%;
}
</style>
