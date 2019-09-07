<template>
  <v-app>
    <v-app-bar app>
      <v-toolbar-title class="headline">
        <v-icon>mdi-movie-roll</v-icon>
        <span>Movie Explorer</span>
      </v-toolbar-title>
    </v-app-bar>

    <v-content>
      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
import { watch } from "fs";
export default {
  data: () => ({
    dark: true
  }),
  created() {
    this.$vuetify.theme.dark = this.dark;
  },
  watch: {
    dark(value) {
      this.$vuetify.theme.dark = value;
    }
  }
};
</script>
