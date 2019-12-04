<template>
    <div id="home-background">
        <div id="home-title">
            <span>Chiva</span>
        </div>
        <div id="home-context">
            <articleItem :pagetitle="title" :describe="de" :href="href" :read="1" :like="2" :command="65"/>
        </div>
    </div>
</template>

<script>
import articleItem from '../ArticleItem.vue'

export default {
    data(){
        return{
            title:"你好啊",
            de:"这里是描述信息",
            href:"#nihao"            
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
}

#home-title span{
    font-size: 60px;

}

</style>