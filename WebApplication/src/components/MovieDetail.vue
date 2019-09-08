<template>
  <Loading :url="`/${id}`">
    <template #default="{data}">
      <v-card>
        <v-card-title>{{ data.title }}</v-card-title>
        <v-row class="py-4 pl-4">
          <v-col class="shrink">
            <v-img :src="buildUrl(data.poster_path, 'w780')"></v-img>
          </v-col>
          <v-col class="text-center">
            <v-container class="pa-0">
              <v-row>
                <v-col>
                  <v-btn icon>
                    <v-icon>mdi-heart</v-icon>
                  </v-btn>
                </v-col>
                <v-col>
                  <v-btn icon>
                    <v-icon>mdi-bookmark</v-icon>
                  </v-btn>
                </v-col>
                <v-col>
                  <v-btn icon>
                    <v-icon>mdi-share-variant</v-icon>
                  </v-btn>
                </v-col>
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
<style lang="less" scoped></style>
