<template>
  <v-content class="pa-0">
    <v-container fluid class="main-container">
      <v-flex lg10 offset-lg1>
        <MovieDetailLazy :id="id" />
      </v-flex>
    </v-container>
  </v-content>
</template>
<script>
import MovieDetailLazy from "../components/MovieDetailLazy";
export default {
  name: "movie",
  components: {
    MovieDetailLazy
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
