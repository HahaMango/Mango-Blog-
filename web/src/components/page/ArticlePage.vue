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
            </div>
            <comment id="comment-test" v-on:CommentClick="commentClick"/>
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
            replyText :""
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
        });
        
        Http.GetComments(id,0,10,function(comments) {
            for(var i =0;i<comments.length;i++){
                p.commentItems.push(comments[i]);
            }
        });

        var i =1;
    },
    methods:{
        ClickEvent:function(event){
            window.alert(event);
        },
        commentClick:function(username,content) {
            var comment = new Comment("",username,content,new Date);
            Http.AddComment(this.id,comment,function(commentjson) {
                p.commentItems.push(comment);
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
</style>