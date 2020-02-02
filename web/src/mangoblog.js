import Vue from 'vue';
import blogapp from './components/MangoBlog.vue';
import './mangoblog.css';

var v = new Vue({
    el: '#mangoblog',
    data: {
        herfhash: '#home'
    },
    render(h) {
        var urlh = window.location.href;
        if(urlh.search('#article')>0||urlh.search("admin")>0){
            this.herfhash = urlh;
        }else{
            window.location.hash = this.herfhash;
        }
        return h(blogapp, {
            props: {
                hash: this.herfhash
            }
        });
    }
})

window.onhashchange = function(){
    v.herfhash = window.location.hash;
};