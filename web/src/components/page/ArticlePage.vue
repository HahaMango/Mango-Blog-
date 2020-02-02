<template>
    <div id="article-background">
        <div id="article-head">
            <span>
                <a href="#home">
                    <span>
                        <ion-icon name="arrow-round-back"></ion-icon>
                    </span>
                </a>
                <span>Chiva</span>
            </span>
        </div>
        <hr/>
        <div id="article-title">
            <h2>{{title}}</h2>
            <div id="article-subtitle">
                <articleInfo style="float:right;" :read="read" :like="like" :comment="comment"/>
                <p>{{date}}</p>
            </div>
            <div id="editor">

            </div>
        </div>
        <hr/>
        <div>
            <div v-if="commentItems.length != 0">
                <h3>评论</h3>
                <commentItem 
                    v-for="c in commentItems"
                    class="commentitem-test" 
                    :key="c.Id"
                    v-on:reply="ClickEvent" 
                    :username="c.UserName"
                    :comment="c.Comment"
                    :date="c.Date"/>
                <div class="text-center" style="margin-top:20px;">
                    <button id="more-comment" v-on:click="GetMoreComment">更多 <ion-icon name="arrow-dropdown"></ion-icon></button>
                </div>
            </div>
            <comment id="comment-test" v-on:CommentClick="commentClick"/>
        </div>
        <div id="like-div">
            <button class="btn btn-light" id="to-top-button" v-on:click="ToTopButton"><ion-icon name="arrow-round-up"></ion-icon></button>            
            <button class="btn btn-light" id="like-button" v-on:click="LikeButton"><ion-icon name="heart-empty"></ion-icon></button>
        </div>
    </div>
</template>

<script>
//API获取文章信息
//API获取文章内容
//API点赞文章
//API阅读数加一
//API获取该文章中的评论（分页）
import articleInfo from '../ArticleInfo.vue';
import comment from '../Comment.vue'
import commentItem from '../CommentItem.vue'
import Http from '../../Communication.js'
import Comment from '../../Comment.js'
import Helper from '../../Helper.js'

let p = null;

export default {
    data(){
        return{
            id:null,
            title:null,
            date:null,
            content:null,
            read:0,
            like:0,
            comment:0,
            commentItems:[],
            replyText :"",
            currentDate:new Date()
        }
    },
    created:function(){  
        p = this;
        var id = window.location.hash;
        id = id.slice(8,id.length);
        p.id = id;
        Http.GetArticle(id,function(article) {
            p.id = id;
            p.title = article.Title;
            p.date = article.Date;
            p.read = article.Read;
            p.like = article.Like;
            p.comment = article.Comment;
        });        
        
        Http.GetArticleContent(id,function(content) {
            p.content = content.Content;
            var testView = editormd.markdownToHTML("editor",{
                markdown:p.content,
                padding:"0px"
            });
            Http.Read(p.id,function(){
                p.read = p.read + 1;
            });
        });

        var s = Helper.LocalToPlues8String(new Date());
        p.currentDate = s;

        Http.GetComments(id,s,10,function(comments) {
            for(var i =0;i<comments.length;i++){
                p.commentItems.push(comments[i]);
            }
        });

        var i =1;
    },
    mounted:function(){
        var likediv = document.getElementById('like-div');
        var width = document.body.clientWidth; 
        var scrollheight = document.documentElement.scrollTop;
        likediv.style.left = (width - 100) + 'px';
        likediv.style.top = (scrollheight + 400) + 'px';
        likediv.style.position = "absolute";
        likediv.style.width = "50px";
        likediv.style.height = "130px";
        window.onscroll = function(){
            scrollheight = document.documentElement.scrollTop;
            likediv.style.top = (scrollheight + 400) + 'px';
        }
    },
    methods:{
        ClickEvent:function(event){
            window.alert(event);
        },
        commentClick:function(username,content) {
            var comment = new Comment("",username,content,Helper.LocalToPlues8String(new Date()));
            Http.AddComment(this.id,comment,function() {
                p.commentItems.unshift(comment);
            });
        },
        ToTopButton:function(){
            document.documentElement.scrollTop = 0;
        },
        LikeButton:function(){
            Http.Like(this.id,function(){
                p.like = p.like + 1;
                alert("点赞成功");
            });
        },
        GetMoreComment:function(){
            var cl = p.commentItems.length-1;
            p.currentDate = p.commentItems[cl].Date;
            Http.GetComments(p.id,p.currentDate,10,function(comments) {
                for(var i =0;i<comments.length;i++){
                    p.commentItems.push(comments[i]);
                }
            });
        }
    },
    components:{
        articleInfo,
        comment,
        commentItem
    }
}
</script>

<style>

#more-comment{
    background-color: rgb(243, 243, 243);
    border-color: transparent;
    border-radius: 10px;
    width: 300px;
}

#article-background{
    width: 100%;
    margin-top: 40px;
}

#article-head span{
    font-size: 30px;
}

#article-head a{
    color: gray;
}

#article-head a:hover{
    color: black;
}

#article-title{
    margin-top: 10px;
}

#article-subtitle{
    margin-top: 20px;
    color: gray;
}

#editor{
    padding-left: 0px;
    padding-right: 0px;
}

#comment-test{
    width: 500px;
    margin-top: 10px;
    margin-left: 370px;
}

.commentitem-test{
    width: 850px;
    margin: 10px auto 0px auto;
    color: gray;
}

#to-top-button{
    margin: 2px 0px 2px 0px;
    font-size: 24px;
}

#like-button{
    margin: 2px 0px 2px 0px;
    font-size: 24px;
}
</style>