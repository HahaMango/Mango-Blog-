<template>
  <div class="blog-context">
    <div class="context">
      <homePage v-if="hash=='#a'" />
      <articlePage v-if="hash=='s'"/>
    </div>
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

.blog-context{
  width: 100%;
}

.context{
  width: 700px;
  margin: 0px auto 0px auto;
}

</style>