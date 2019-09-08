<template>
  <v-app>
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
    </v-app-bar>

    <v-content>
      <router-view :key="$route.fullPath"></router-view>
    </v-content>
  </v-app>
</template>

<script>
export default {
  data: () => ({
    dark: false
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
