<template>
  <div>
    <div>Movie {{ id }}</div>
    <MovieDetail :id="id" />
  </div>
</template>
<script>
import MovieDetail from "../components/MovieDetail";
export default {
  name: "movie",
  components: {
    MovieDetail
  },
  props: {
    id: {
      required: true,
      type: String
    }
  }
};
</script>
<style lang="less" scoped></style>
