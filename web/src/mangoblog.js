import Vue from 'vue';
import blogapp from './components/MangoBlog.vue';

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

var editor = editormd("editor", {
    // width: "100%",
    // height: "100%",
    // markdown: "xxxx",     // dynamic set Markdown text
    path : "editor.md/lib/"  // Autoload modules mode, codemirror, marked... dependents libs path
});