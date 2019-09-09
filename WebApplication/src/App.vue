<template>
  <v-app class="application">
    <v-app-bar app>
      <v-toolbar-title>
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-btn text :to="{ name: 'home' }" rounded v-on="on">
              <v-icon left>mdi-movie-roll</v-icon>
              Upcoming movies
            </v-btn>
          </template>
          <span class="caption">Home</span>
        </v-tooltip>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn v-if="loading" text loading></v-btn>
      <v-text-field
        v-if="showSearch"
        class="search"
        hide-details
        rounded
        outlined
        solo
        flat
        append-icon="mdi-magnify"
        v-model="searchInformation"
        height="2px"
        label="Search"
      ></v-text-field>
    </v-app-bar>

    <v-content class="content">
      <router-view :key="$route.fullPath"></router-view>
    </v-content>
  </v-app>
</template>

<script>
import { mapState } from "vuex";

export default {
  name: "main-application",
  created() {
    this.$vuetify.theme.dark = false;
  },
  computed: {
    ...mapState(["showSearch", "loading"]),
    searchInformation: {
      get() {
        return this.$store.state.searchInformation;
      },
      set(value) {
        this.$store.commit("updateSearchInformation", value);
      }
    }
  }
};
</script>
<style scoped>
.search {
  max-width: 30%;
}
.application {
  width: 100%;
}

.application >>> .v-application--wrap {
  width: 100%;
}

.content >>> .v-content__wrap {
  width: 100%;
}
</style>
