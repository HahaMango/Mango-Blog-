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
        <input class="col-sm-10 mango-text-input" type="text" placeholder="请填写文章标题..." />
      </div>
      <div class="row" style="margin-top:10px;">
        <span class="col-sm-2">文章简述：</span>
        <input class="col-sm-10 mango-text-input" type="text" placeholder="请填写文章简述内容..." />
      </div>
      <div class="row" style="margin-top:10px;">
        <span class="col-sm-2">文章分类：</span>
        <input class="col-sm-10 mango-text-input" type="text" placeholder="请填写文章分类..." />
      </div>
    </div>
    <div id="editor"></div>
    <div id="editor-button-div">
      <button type="button" class="btn btn-outline-secondary">发布</button>
    </div>
    <div id="editor-bit"></div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      editorHeight : 500
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