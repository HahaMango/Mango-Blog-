<template>
  <div class="article-item" onmouseover="this.className='article-item-hold'" onmouseout="this.className='article-item'">
    <div class="item-border">
      <a :href="href">
        <div>
          <h2>{{pagetitle}}</h2>
          <span style="display:block;margin-bottom:10px;">{{describe}}</span>
          <articleInfo class="article-item-info" :read="read" :like="like" :comment="comment"/>
        </div>
      </a>
    </div>
  </div>
</template>

<script>
import articleInfo from './ArticleInfo.vue';

export default {
    props:["pagetitle","describe","href","read","like","comment"],
    components:{
        articleInfo
    },
    methods:{
    }
}
</script>

<style>

.article-item{
    margin: 5px 0px 5px 0px;
    padding: 23px 15px 23px 15px;
}

.article-item-hold{
    margin: 5px 0px 5px 0px;
    padding: 23px 15px 23px 15px;
    background-color: rgb(245, 245, 245);
    border-radius: 5px;
}

.article-item-info {
    float:right;
}

.article-item a {
  text-decoration:none;
  color: rgb(182, 182, 182);
}

.article-item-hold a {
  text-decoration:none;
  color: rgb(182, 182, 182);
}

.article-item-hold a:hover{
    color: black;
    text-decoration:none;
}

</style>