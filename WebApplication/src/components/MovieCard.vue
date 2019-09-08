<template>
  <FlipCard
    @mouseover.native="flipped = true"
    @mouseleave.native="flipped = false"
    :flipped="flipped"
    width="200px"
    height="400px"
  >
    <template #front>
      <!-- <v-img class="white--text" height="100%" :src="image" style="position:absolute;">
      </v-img> -->
      <div class="card-side" :style="{ background }"></div>
    </template>

    <template #back>
      <div class="card-side back">
        <div class="v-card__title">{{ title }}</div>
        <div class="v-card__text">I'm card text</div>
        <div class="v-card__actions">
          <v-btn class="mx-2" fab dark small color="primary">
            <v-icon dark>mdi-minus</v-icon>
          </v-btn>
        </div>
      </div>
      <!-- -->

      <!--  <v-card class="card-side back">
        <v-card-title>{{ title }}</v-card-title>
        <v-card-text>I'm card text</v-card-text>
       <v-card-actions class="actions">
         <v-btn
            class="actions"
          >Click</v-btn>
        </v-card-actions> 
      </v-card>-->
    </template>
  </FlipCard>
</template>
<script>
import FlipCard from "./FlipCard";
export default {
  components: {
    FlipCard
  },
  data: () => ({
    flipped: false
  }),
  props: {
    image: {
      required: true,
      type: String
    },
    title: {
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

.card-side {
  margin: 0;
  width: 100%;
  height: 100%;
}

.back {
  background: grey;
}
</style>
