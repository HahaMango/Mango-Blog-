# 个人博客后台Web API接口

[![Build Status](https://dev.azure.com/q932104843/blog/_apis/build/status/HahaMango.Mango-Blog-?branchName=master)](https://dev.azure.com/q932104843/blog/_build/latest?definitionId=3&branchName=master)

|API|请求方法|描述|
|:--:|:--:|:--:|
|api/articles|POST|添加文章|
|api/articles/{start}/{count}|GET|分页查询|
|api/articles|GET|全表查询|
|api/articles/content/{id}|GET|查询文章内容|
|api/articles/like/{id}|PUT|点赞操作|
|api/articles/read/{id}|PUT|递增阅读数|
|api/comments/article/{id}/{start}/{count}|GET|获取文章评论|
|api/comments/article/{id}|POST|新建评论|
|api/categories|POST|添加分类|
|api/categories|GET|获取所有分类|
|api/categories/articles/{id}|GET|获取文章分类|
