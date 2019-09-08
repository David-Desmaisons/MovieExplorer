<template>
  <v-app>
    <v-app-bar app>
      <v-toolbar-title>
        <v-icon>mdi-movie-roll</v-icon>
        <span>Upcoming movies</span>
      </v-toolbar-title>
    </v-app-bar>

    <v-content>
      <router-view :key="$route.fullPath"></router-view>
    </v-content>
  </v-app>
</template>

<script>
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
