<template>
  <div id="editor-div">
    <div id="editor-head">
      <span>Chiva</span>
      <span>
        <i>blog</i>
      </span>
    </div>
    <div id="editor-title">
      <div class="row">
        <span class="col-sm-2">文章标题：</span>
        <input class="col-sm-8 mango-text-input" type="text" maxlength="100" placeholder="请填写文章标题..." v-model="title" v-on:keyup="TitleChange($event)"/>
        <div class="col-sm-2"><span id="title-count">0</span>/100</div>
      </div>
      <div class="row" style="margin-top:10px;">
        <span class="col-sm-2">文章简述：</span>
        <input class="col-sm-8 mango-text-input" type="text" maxlength="300" placeholder="请填写文章简述内容..." v-model="describe" v-on:keyup="DescChange($event)"/>
        <div class="col-sm-2"><span id="describe-count">0</span>/300</div>
      </div>
      <div class="row" style="margin-top:10px;">
        <span class="col-sm-2">文章分类：</span>
        <input class="col-sm-8 mango-text-input" type="text" placeholder="请填写文章分类..." v-model="category"/>
      </div>
    </div>
    <div id="editor"></div>
    <div id="editor-button-div">
      <button type="button" class="btn btn-outline-secondary" v-on:click="publishClick">发布</button>
    </div>
    <div id="editor-bit"></div>
  </div>
</template>

<script>
import ArticleModel from '../../ArticleModel.js'
import Http from "../../Communication.js"

export default {
  data() {
    return {
      editorHeight : 500,
      editor:null,
      title:null,
      describe:null,
      category:null,
      content:null,
      contentType:'md'
    };
  },
  mounted: function() {
    var sHeight = document.documentElement.clientHeight;
    sHeight -= 350;
    this.editorHeight = sHeight;

    var editor = editormd("editor", {
      width: "100%",
      height: this.editorHeight + 'px',
      // markdown: "xxxx",     // dynamic set Markdown text
      path: "editor.md/lib/" // Autoload modules mode, codemirror, marked... dependents libs path
    });

    this.editor = editor;
  },
  methods:{
    publishClick:function() {
      this.content = this.editor.getMarkdown();
      
      var articleModel = new ArticleModel(this.title,this.describe,this.category,this.content,this.contentType);
      
      Http.AddArticle(articleModel,function() {
        alert("文章发布成功")
      })
    },
    TitleChange:function(input){
      var titleCount = document.getElementById('title-count');
      var input = input.target.value;
      titleCount.innerText = input.length;
    },
    DescChange:function(input){
      var titleCount = document.getElementById('describe-count');
      var input = input.target.value;
      titleCount.innerText = input.length;
    }
  }
};
</script>

<style>
#editor-div {
}

#editor-head {
  width: 155px;
  margin: 0px auto 0px auto;
}

#editor-head span:first-child {
  font-size: 40px;
  margin: 0px auto 0px auto;
}

#editor-head span:last-child {
  font-size: 20px;
  margin-left: 20px;
}

#editor-title {
  width: 660px;
  margin-top: 10px;
  margin-left: 30px;
  margin-bottom: 10px;
}

#editor-bit{
  height: 38px;
}

#editor-button-div {
  float: right;
  margin-right: 50px;
}
</style>