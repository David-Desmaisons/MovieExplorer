<template>
  <v-content>
    <v-container fluid class="main-container">
      <v-flex lg10 offset-lg1>
        <MovieDetail :id="id" />
      </v-flex>
    </v-container>
  </v-content>
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
