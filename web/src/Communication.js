import ArticleItem from './ArticleItem.js'
import ArticleContent from './ArticleContent.js';
import Comment from './Comment.js'

let url = "api/";

export default{
    GetArticle:function(id,success){
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.open("GET",url+"articles/"+id,true);
        xmlhttp.setRequestHeader("Access-Control-Allow-Origin","*");
        xmlhttp.setRequestHeader("Accept","application/json");
        xmlhttp.onreadystatechange = function(){
            if(xmlhttp.readyState == 4 && xmlhttp.status == 200){
                var json = JSON.parse(xmlhttp.responseText);
                var articleitem = new ArticleItem(json.title,json.describe,'#article'+json.id,json.read,json.like,json.comment,json.category,json.date.replace('T'," "));
                success(articleitem);
            }
        }
        xmlhttp.send();
    },
    GetArticles:function(startIndex,count,success){
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.open("GET",url + "articles/"+startIndex + "/"+count,true);
        xmlhttp.setRequestHeader("Access-Control-Allow-Origin","*");
        xmlhttp.setRequestHeader("Accept","application/json");
        xmlhttp.onreadystatechange = function(){
            if(xmlhttp.readyState == 4 && xmlhttp.status == 200){
                var json = JSON.parse(xmlhttp.responseText);
                var articleItems = new Array();
                for(var i = 0;i<json.length;i++){
                    var article = json[i];
                    var articleitem = new ArticleItem(article.title,article.describe,'#article'+article.id,article.read,article.like,article.comment,article.category,article.date.replace('T'," "));
                    articleItems.push(articleitem);
                }                
                success(articleItems);
            }
        }
        xmlhttp.send();
    },
    GetArticleContent:function(id,success){
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.open("GET",url + "articles/content/"+id,true);
        xmlhttp.setRequestHeader("Access-Control-Allow-Origin","*");
        xmlhttp.setRequestHeader("Accept","application/json");
        xmlhttp.onreadystatechange = function(){
            if(xmlhttp.readyState == 4 && xmlhttp.status == 200){
                var json = JSON.parse(xmlhttp.responseText);
                var content = new ArticleContent(json.articleId,json.content,json.contentType);
                success(content);
            }
        }
        xmlhttp.send();
    },
    Like:function(id,success){
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.open("PUT",url + "articles/like/"+id,true);
        xmlhttp.setRequestHeader("Access-Control-Allow-Origin","*");
        xmlhttp.setRequestHeader("Accept","application/json");
        xmlhttp.onreadystatechange = function(){
            if(xmlhttp.readyState == 4 && xmlhttp.status == 200){
                success();
            }
        }
        xmlhttp.send();
    },
    Read:function(id,success){
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.open("PUT",url + "articles/read/"+id,true);
        xmlhttp.setRequestHeader("Access-Control-Allow-Origin","*");
        xmlhttp.setRequestHeader("Accept","application/json");
        xmlhttp.onreadystatechange = function(){
            if(xmlhttp.readyState == 4 && xmlhttp.status == 200){
                var ok = JSON.parse(xmlhttp.responseText);
                success(ok);
            }
        }
        xmlhttp.send();
    },
    GetComments:function(id,startIndex,count,success){
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.open("GET",url + "comments/article/"+id+"/"+startIndex+"/"+count,true);
        xmlhttp.setRequestHeader("Access-Control-Allow-Origin","*");
        xmlhttp.setRequestHeader("Accept","application/json");
        xmlhttp.onreadystatechange = function(){
            if(xmlhttp.readyState == 4 && xmlhttp.status == 200){
                var commentsJson = JSON.parse(xmlhttp.responseText);
                var comments = new Array();
                for(var i =0;i<commentsJson.length;i++){
                    var commentJson = commentsJson[i];
                    var comment = new Comment(commentJson.id,commentJson.userName,commentJson.comment,commentJson.date.replace('T'," "));
                    comments.push(comment);
                }
                success(comments);
            }
        }
        xmlhttp.send();
    },
    AddArticle:function(articleModel,success){
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.open("POST",url + "articles",true);
        xmlhttp.setRequestHeader("Access-Control-Allow-Origin","*");
        xmlhttp.setRequestHeader("Accept","application/json");
        xmlhttp.setRequestHeader("Content-Type","application/json")
        var jsonsource = JSON.stringify(articleModel);
        xmlhttp.onreadystatechange = function(){
            if(xmlhttp.readyState == 4 && xmlhttp.status == 200){
                success();
            }
            if(xmlhttp.readyState ==4 && xmlhttp.status >= 400){
                alert("文章发布失败");
            }            
        }
        xmlhttp.send(jsonsource);
    },
    AddComment:function(id,comment,success){
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.open("POST",url + "comments/article/"+ id,true);
        xmlhttp.setRequestHeader("Access-Control-Allow-Origin","*");
        xmlhttp.setRequestHeader("Accept","application/json");
        xmlhttp.setRequestHeader("Content-Type","application/json")
        var jsonsource = JSON.stringify(comment);
        xmlhttp.onreadystatechange = function(){
            if(xmlhttp.readyState == 4 && xmlhttp.status == 200){
                success();
            }
            
        }
        xmlhttp.send(jsonsource);
    }
}