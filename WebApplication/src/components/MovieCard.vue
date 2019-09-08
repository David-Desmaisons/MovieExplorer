<template>
  <div>
    <MovieInformation
      v-if="!movie.poster_url"
      class="information"
      :movie="movie"
    />
    <FlipCard
      v-else
      @mouseover.native="flipped = true"
      @mouseleave.native="flipped = false"
      :flipped="flipped"
      width="200px"
      height="400px"
    >
      <template #front>
        <div class="card-side" :style="{ background }"></div>
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
.card {
  height: 300px;
  width: 200px;
}

.image {
  width: 100%;
  height: 100%;
}

.card-side {
  margin: 0;
  width: 100%;
  height: 100%;
}

.back {
  background: grey;
}

.information {
  width: 200px;
  height: 400px;
  background: grey;
  margin: 5px;
}
</style>
