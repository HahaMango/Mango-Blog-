<template>
  <div class="article-item">
    <div class="item-border" onmouseover="this.className='item-border-hold'" onmouseout="this.className='item-border'">
      <a :href="href">
        <div>
          <h2>{{pagetitle}}</h2>
          <span>{{describe}}</span>
          <articleInfo class="article-item-info" :read="read" :like="like" :command="command"/>
        </div>
      </a>
    </div>
  </div>
</template>

<script>
import articleInfo from './ArticleInfo.vue';

export default {
    props:["pagetitle","describe","href","read","like","command"],
    components:{
        articleInfo
    }
}
</script>

<style>

.article-item{
    padding: 15px 0px 15px 0px
}

.article-item-info {
    float:right;
}

.article-item a {
  text-decoration:none;
  color: rgb(182, 182, 182);
}

.item-border-hold a:hover{
    color: black;
    text-decoration:none;
}

</style>