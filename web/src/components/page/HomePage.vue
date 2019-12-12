<template>
    <div id="home-background">
        <div id="home-title">
            <span>Chiva</span>
        </div>
        <div id="home-context">
            <articleItem 
                v-for="article in articles" 
                :key="article.Href"
                :pagetitle="article.Title"
                :describe="article.Describe"
                :href="article.Href"
                :read="article.Read"
                :like="article.Like"
                :comment="article.Comment"
                />
        </div>
    </div>
</template>

<script>
//API：获取文章信息（分页）
import articleItem from '../ArticleItem.vue'
import ArticleItem from '../../ArticleItem.js'

export default {
    data(){
        return{
            articles:[
                new ArticleItem('文章','描述信息','#abd',1,10,34),
                new ArticleItem('somearticle','somedec','#54',10,14,20),
                new ArticleItem('somearticle','somedec','#54',10,14,20),
                new ArticleItem('somearticle','somedec','#54',10,14,20)
            ]
        }
    },
    components:{
        articleItem
    }
}
</script>

<style>

#home-background{
    margin-top: 50px;
    width: 100%;
}

#home-title{
    margin-bottom: 50px;
    margin-left: 10px;
}

#home-title span{
    font-size: 60px;

}

</style>