<template>
    <div class="profile-title">
        <h1>Profile</h1>
        <div id="editor">

        </div>
    </div>    
</template>

<script>
export default {
    mounted:function(){
        var testView = editormd.markdownToHTML("editor",{
            markdown:'### **姓名：陈子华**\n\n#### **学历：大专 佛山职业技术学院**\n\n#### **专业：电气自动化**\n\nEmail：q932104843@outlook.com\n\nGithub：https://github.com/HahaMango\n\n微信公众号：ChivaStudio\n\n***\n\n该网站是本人业余时间从后端到前端重头自己搭建的，平时空闲会写写一些技术分享文章，希望大家喜欢。\n\n本人目前在广州工作，曾从事大型机械设备程序的开发（PLC），目前在广州从事软件开发工作。比较擅长`.Net`，`.Net Core`平台的开发。如有工作需要可以发邮件到上面我的邮箱里面。',
            padding:"0px"
        });
    }
}
</script>

<style>

.profile-title{
    margin-top: 50px;
}

</style>