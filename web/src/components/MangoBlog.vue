<template>
  <div>
    <homepage v-if="hash=='/'" />
    <articlePage v-if="hash =='/art'"/>
  </div>
</template>

<script>
import homePage from "./page/HomePage.vue";
import articlePage from "./page/ArticlePage.vue";

export default {
  props: ["hash"],
  components: {
    homePage,
    articlePage
  }
};
</script>

<style>
</style>