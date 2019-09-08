<template>
  <Loading :url="`/${id}`">
    <template #loading>
      <v-card>
        <v-row class="py-4 pl-4">
          <v-col>
            <div class="place-holder"></div>
          </v-col>
          <v-col>
            <v-container class="pa-0">
              <v-row> </v-row>
            </v-container>
          </v-col>
        </v-row>
      </v-card>
    </template>
    <template #default="{data}">
      <v-card>
        <v-row class="py-4 pl-4">
          <v-col>
            <v-img
              aspect-ratio="1"
              contain
              :src="buildUrl(data.poster_path, 'w780')"
            >
              <template #placeholder>
                <div class="place-holder"></div>
              </template>
            </v-img>
          </v-col>
          <v-col>
            <v-container class="pa-0">
              <v-row>
                <v-card-title>{{ data.title }}</v-card-title>
              </v-row>
              <v-row>
                <v-rating
                  :value="data.vote_average / 2"
                  readonly
                  small
                  color="yellow"
                  background-color="grey lighten-1"
                ></v-rating>
              </v-row>
              <v-row>
                <span>{{ data.overview }}</span>
              </v-row>
            </v-container>
          </v-col>
        </v-row>
      </v-card>
    </template>
  </Loading>
</template>
<script>
import Loading from "./Loading";
import { buildUrl } from "../infra/urlBuilder";

export default {
  name: "movie-detail",
  components: {
    Loading
  },
  props: {
    id: {
      required: true,
      type: String
    }
  },
  methods: {
    buildUrl
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
