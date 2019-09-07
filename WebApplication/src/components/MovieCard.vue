<template>
  <v-card class="mx-auto" width="200px" height="400px">
    <v-img height="100%" :src="image">
    </v-img>
  </v-card>
</template>
<script>
export default {
  props: {
    image: {
      required: true,
      type: String
    },
    title:{
      required: true,
      type: String
    }
  },
  computed: {
    background() {
      return `url('${this.image}') center/cover no-repeat`;
    }
  }
};
</script>
<style lang="less" scoped>
.card {
  height: 300px;
  width: 200px;
}

.image {
  width: 100%;
  height: 100%;
}
</style>
