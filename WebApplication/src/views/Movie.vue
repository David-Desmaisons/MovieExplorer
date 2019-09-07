<template>
  <div>Movie {{ id }}</div>
</template>
<script>
export default {
  props: {
    id: {
      required: true,
      type: String
    }
  }
};
</script>
<style lang="less" scoped></style>
