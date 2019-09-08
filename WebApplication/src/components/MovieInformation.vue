<template>
  <v-card>
    <v-card-title class="normal">{{ movie.title }}</v-card-title>
    <v-card-text>{{ movie.release_date}}</v-card-text>
    <v-divider class="ml-auto"></v-divider>
    <v-card-actions>
      <v-btn
        class="mx-2"
        fab
        dark
        small
        color="primary"
      >
        <v-icon dark>mdi-alert-circle</v-icon>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
export default {
  props: {
    movie: {
      required: true,
      type: Object
    }
  }
};
</script>
<style lang="less" scoped>

.normal {
  word-wrap: normal;
}
</style>
