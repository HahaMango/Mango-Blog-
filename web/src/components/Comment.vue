<template>
    <div id="comment-background">
        <div>
            <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" v-model="text"></textarea>
        </div>
        <div class="row" id="comment-userinfo">
            <div class="col-sm-6"></div>
            <label class="col-sm-2 col-form-label" >用户名:</label>
            <input class="col-sm-2 form-control" type="text" v-model="username"/>
            <div class="col-sm-2">
                <button class="btn btn-primary" v-on:click="commentClick">评论</button>
            </div>
        </div>
    </div>
</template>

<script>
//API：发布评论
export default {
    data(){
        return {
            username:"",
            text:""
        }
    },
    methods:{
        commentClick:function() {
            this.$emit('CommentClick',this.username,this.text);
            this.username = "";
            this.text = "";
        }
    }
}
</script>

<style>

#comment-userinfo{
    margin-top: 10px;
}

</style>