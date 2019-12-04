import Vue from 'vue';
import blogapp from './components/MangoBlog.vue';
//import './mangoblog.css'


var v = new Vue({
    el: '#mangoblog',
    data: {
        herfhash: '#a'
    },
    render(h) {
        return h(blogapp, {
            props: {
                hash: this.herfhash
            }
        });
    }
})
