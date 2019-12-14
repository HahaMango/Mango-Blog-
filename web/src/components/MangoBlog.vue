<template>
  <div class="blog-context">
    <div :class="[(hash!='#admin')?'context':'']">
      <homePage v-if="hash=='#a'" />
      <articlePage v-if="hash=='#s'"/>
      <adminPage v-if="hash=='#admin'"/>
    </div>
    <div>
      <div class="blog-footer">
        <span>粤ICP备18149049号</span>
        <span style="margin-left:40px;"><a href="https://github.com/HahaMango/Mango-Blog-" target="_blank"><ion-icon name="logo-github"></ion-icon></a><i>Power By .Net Core</i></span>
      </div>
    </div>
  </div>
</template>

<script>
//API：获取文章信息（分页）
//API：获取文章信息
//API：获取文章内容
//API：点赞文章
//API：获取文章总数
//API：获取该文章中的评论（分页）
//API：发布评论
import homePage from "./page/HomePage.vue";
import articlePage from "./page/ArticlePage.vue";
import adminPage from './page/AdminPage.vue';

export default {
  props: ["hash"],
  components: {
    homePage,
    articlePage,
    adminPage
  }
};
</script>

<style>

.blog-context{
  width: 100%;
}

.context{
  width: 900px;
  margin: 0px auto 0px auto;
}

.blog-footer{
  width: 340px;
  margin: 0px auto 0px auto;
  color: gray;
  padding-top: 10px;
  padding-bottom: 40px;
}

.blog-footer a{
  color: gray;
}

</style>