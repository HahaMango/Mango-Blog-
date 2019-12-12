<template>
    <div class="comment-item">
        <p><b>{{username}}</b></p>
        <p>{{comment}}</p>
        <a href="#" v-on:click="clicka"><span><ion-icon name="undo"></ion-icon></span></a>
        <span style="font-size:12px;">{{date}}</span>
    </div>    
</template>

<script>
export default {
    props:["username","comment","date"],
    methods:{
        clicka:function(event){
            this.$emit('reply',username);
        }
    }
}
</script>

<style>
.comment-item{
    border-bottom-style: solid;
    border-width: 1px;
    border-color: rgb(228, 228, 228);
}

.comment-item a{
    color: gray;
    float: right;
}

.comment-item a:hover{
    color: black;
}
</style>