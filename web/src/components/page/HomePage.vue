<template>
    <div id="home-background">
        <div id="home-title" class="row">
            <span class="col-sm-3">Chiva</span>
            <div class="col-sm-3"></div>
            <div class="col-sm-2"></div>
            <div class="col-sm-2"></div>
            <div class="col-sm-2">
                <button id="profile-button" class="btn btn-light" v-on:click="ProfileClick">
                    <ion-icon name="bookmark"></ion-icon>Profile
                </button>
            </div>
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
import Http from '../../Communication.js'

let p = null;

export default {
    data(){
        return{
            articles:[
            ]
        }
    },
    created : function() {

        p = this;
        Http.GetArticles(0,10,function(articles) {
            for(var i =0;i<articles.length;i++){
                p.articles.push(articles[i]);
            }
        })
    },
    components:{
        articleItem
    },
    methods:{
        ProfileClick:function(){
            window.location.hash = "#profile";
        }
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

#profile-button{
    margin-top: 40px;
}
</style>