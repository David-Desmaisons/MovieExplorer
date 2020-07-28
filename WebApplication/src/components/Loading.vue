<template>
  <div>
    <slot v-if="loading" name="loading">
      <div>Loading ...</div>
    </slot>
    <slot v-else-if="error" name="error" v-bind="{ error }">
      <div>{{ error }}</div>
    </slot>
    <slot v-else v-bind="{ data }"></slot>
  </div>
</template>

<script>
export default {
  name: "loading",
  props: {
    url: {
      type: String,
      required: true
    }
  },
  data: () => ({
    loading: true,
    data: null,
    error: null
  }),
  async created() {
    try {
      this.data = await this.$get(this.url);
      this.loading = false;
    } catch (error) {
      this.error = error;
      this.loading = false;
    }
  }
};
</script>
