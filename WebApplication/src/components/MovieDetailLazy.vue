<template>
  <Loading :url="`/${id}`">
    <template #loading>
      <v-card>
        <v-row class="py-4 pl-4">
          <v-col :sm="6">
            <div class="place-holder"></div>
          </v-col>
          <v-col :sm="4"> </v-col>
        </v-row>
      </v-card>
    </template>
    <template #default="{data}">
      <MovieDetail :movie="data" />
    </template>
  </Loading>
</template>
<script>
import MovieDetail from "./MovieDetail";
import Loading from "./Loading";

export default {
  name: "movie-detail-lazy",
  components: {
    Loading,
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
<style lang="less" scoped>
.place-holder {
  background: lightgray;
  height: 750px;
  margin: 0px 130px 0px 120px;
}
</style>
