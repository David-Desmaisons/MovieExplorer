<template>
  <div>
  </div>
</template>
<script>
export default {
  data: () => ({
    loading: true,
    movie: null
  }),
  props: {
    id: {
      required: true,
      type: String
    }
  },
  async created(){
    const res = await this.$get(`/${this.id}`);
    this.movie = res;
  }
};
</script>
<style lang="less" scoped>
</style>
