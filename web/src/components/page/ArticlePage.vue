<template>
    <div id="article-background">
        <div id="article-head">
            <span>
                <a href="#sw">
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
            <commentItem 
                :v-for="com in comments" 
                class="commentitem-test" 
                :key="com.Id" 
                v-on:reply="ClickEvent" 
                :username="com.Username" 
                :comment="com.Comment" 
                :date="com.Date"/>
            <comment id="comment-test" :text="replyText"/>
        </div>
    </div>
</template>

<script>
//API获取文章信息
//API获取文章内容
//API点赞文章
//API获取该文章中的评论（分页）
import articleInfo from '../ArticleInfo.vue';
import comment from '../Comment.vue'
import commentItem from '../CommentItem.vue'

class Comment{
    constructor(id, username,comment,date){
        this.Id = id;
        this.Username = username;
        this.Comment = comment;
        this.Date = date;
    }
}

export default {
    data(){
        return{
            title:null,
            date:null,
            content:null,
            read:0,
            like:0,
            comment:0,
            comments:[],
            replyText :""
        }
    },
    mounted:function(){
        var testView = editormd.markdownToHTML("editor",{
            markdown:"# Hello \n ## 预览",
            padding:"0px"
        });
    },
    methods:{
        ClickEvent:function(event){
            window.alert(event);
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