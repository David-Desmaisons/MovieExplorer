<template>
  <div>
    <MovieInformation
      v-if="!movie.poster_path"
      class="movie-information"
      :movie="movie"
    />
    <FlipCard
      v-else
      @mouseover.native="flipped = true"
      @mouseleave.native="flipped = false"
      :flipped="flipped"
      width="220px"
      height="400px"
    >
      <template #front>
        <v-img :src="movie.poster_path" width="220px" height="400px">
          <template #placeholder>
            <v-row
              class="fill-height ma-0 grey"
              align="center"
              justify="center"
            >
              <v-progress-circular
                indeterminate
                color="black"
              ></v-progress-circular>
            </v-row>
          </template>
        </v-img>
      </template>

      <template #back>
        <MovieInformation class="card-side back" :movie="movie" />
      </template>
    </FlipCard>
  </div>
</template>
<script>
import FlipCard from "./FlipCard";
import MovieInformation from "./MovieInformation";
export default {
  name: "movie-card",
  components: {
    FlipCard,
    MovieInformation
  },
  data: () => ({
    flipped: false
  }),
  props: {
    movie: {
      required: true,
      type: Object
    }
  },
  computed: {
    background() {
      return `url('${this.movie.poster_url}') center/cover no-repeat`;
    }
  }
};
</script>
<style lang="less" scoped>
.image {
  width: 100%;
  height: 100%;
}

.card-side {
  margin: 0;
  width: 220px;
  height: 400px;
}

.back {
  background: grey;
}

.movie-information {
  width: 220px;
  height: 400px;
  background: grey;
  margin: 5px;
}
</style>
