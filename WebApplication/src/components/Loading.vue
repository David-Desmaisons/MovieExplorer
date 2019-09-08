<template>
  <div>
    <slot v-if="loading" name="loading">
      <div>Loading ...</div>
    </slot>
    <slot v-else v-bind="{ data }"> </slot>
  </div>
</template>

<script>
export default {
  name: "loading",
  props: ["url"],
  data: () => ({
    loading: true,
    data: null
  }),
  async created() {
    this.data = await this.$get(this.url);
    this.loading = false;
  }
};
</script>
