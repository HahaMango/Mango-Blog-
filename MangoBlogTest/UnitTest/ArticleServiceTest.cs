using Moq;
using System;
using Xunit;
using MangoBlog.Service;
using MangoBlog.Entity;
using MangoBlog.Service.Imp;
using MangoBlog.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MangoBlogTest.UnitTest
{
    public class ArticleServiceTest
    {
        private readonly IList<ArticleInfoModel> _infoList = null;
        private readonly IList<ArticleContentModel> _articleContents = null;
        private readonly Mock<IArticleDao> _mock = null;

        public ArticleServiceTest()
        {
            _infoList = new List<ArticleInfoModel>
            {
                new ArticleInfoModel
                {
                    Id = "232",
                    Title = "第一篇文章",
                    Describe = "内容描述",
                    Read = 10,
                    Like = 2,
                    Comment = 3,
                    Date = new DateTime(2019, 12, 13)
                },
                new ArticleInfoModel
                {
                    Id = "333",
                    Title = "第二篇文章",
                    Describe = "内容描述",
                    Read = 5,
                    Like = 1,
                    Comment = 1,
                    Date = new DateTime(2019, 10, 1)
                },
                new ArticleInfoModel
                {
                    Id = "133",
                    Title = "第三篇文章",
                    Describe = "内容描述",
                    Read = 45,
                    Like = 10,
                    Comment = 1,
                    Date = new DateTime(2019, 10, 1)
                }
            };

            _articleContents = new List<ArticleContentModel>
            {
                new ArticleContentModel
                {
                    Id = "232",
                    Content = "sfwefw",
                    ContentType = "md"
                },
                new ArticleContentModel
                {
                    Id = "333",
                    Content="sdwwwwwww",
                    ContentType = "md"
                },
                new ArticleContentModel
                {
                    Id = "133",
                    Content = "sdfwccccc",
                    ContentType = "md"
                }
            };

            _mock = new Mock<IArticleDao>();
        }

        [Fact]
        public async void ArticleCountTest()
        {
            _mock.Setup(a => a.ArticleCountAsync()).Returns(Task.FromResult(_infoList.Count));
            ArticleService articleService = new ArticleService(_mock.Object);
            int count = await articleService.ArticleCountAsync();
            Assert.Equal(_infoList.Count, count);
        }

        [Fact]
        public async void GetArticlesTest()
        {
            IList<ArticleInfoModel> r1 = new List<ArticleInfoModel>
            {
                _infoList[0]
            };
            IList<ArticleInfoModel> r2 = new List<ArticleInfoModel>
            {
                _infoList[1],
                _infoList[2]
            };
            _mock.Setup(a => a.GetArticleInfosAsync(It.IsIn<int>(0), It.IsIn<int>(1))).Returns(Task.FromResult(r1));
            _mock.Setup(a => a.GetArticleInfosAsync(It.IsIn<int>(1), It.IsIn<int>(2))).Returns(Task.FromResult(r2));
            _mock.Setup(a => a.GetArticleInfosAsync(It.IsAny<int>(), It.IsIn<int>(0))).Returns(Task.FromResult((IList<ArticleInfoModel>)new List<ArticleInfoModel>()));
            _mock.Setup(a => a.GetArticleInfosAsync(It.IsAny<int>(), It.Is<int>( i => i > 3))).Returns(Task.FromResult(_infoList));
            ArticleService articleService = new ArticleService(_mock.Object);
            var result = await articleService.GetArticleInfosAsync(0, 1);
            Assert.Equal<ArticleInfoModel>(r1, result);

            result = await articleService.GetArticleInfosAsync(1, 2);
            Assert.Equal<ArticleInfoModel>(r2, result);

            result = await articleService.GetArticleInfosAsync(0, 0);
            Assert.Equal<ArticleInfoModel>((IList<ArticleInfoModel>)new List<ArticleInfoModel>(), result);

            result = await articleService.GetArticleInfosAsync(0, 4);
            Assert.Equal<ArticleInfoModel>(_infoList, result);
        }

        [Fact]
        public async void GetAllArticlesTest()
        {
            _mock.Setup(a => a.GetArticleInfosAsync()).Returns(Task.FromResult(_infoList));
            ArticleService articleService = new ArticleService(_mock.Object);
            IList<ArticleInfoModel> articles = await articleService.GetArticleInfosAsync();
            Assert.Equal(_infoList, articles);
        }

        [Fact]
        public async void GetArticleByIdTest()
        {
            _mock.Setup(a => a.GetArticleInfoAsync(It.IsIn("232"))).Returns(Task.FromResult(_infoList[0]));
            _mock.Setup(a => a.GetArticleInfoAsync(It.IsIn("333"))).Returns(Task.FromResult(_infoList[1]));
            _mock.Setup(a => a.GetArticleInfoAsync(It.IsIn("133"))).Returns(Task.FromResult(_infoList[2]));
            ArticleService articleService = new ArticleService(_mock.Object);
            ArticleInfoModel result = await articleService.GetArticleByIdAsync("232");
            Assert.Equal(_infoList[0], result);

            result = await articleService.GetArticleByIdAsync("333");
            Assert.Equal(_infoList[1], result);

            result = await articleService.GetArticleByIdAsync("133");
            Assert.Equal(_infoList[2], result);

            await Assert.ThrowsAsync<NullReferenceException>(async ()=> { await articleService.GetArticleByIdAsync(null); });
        }

        [Fact]
        public async void GetArticleContentByIdTest()
        {
            _mock.Setup(a => a.GetArticleContentAsync(It.IsIn("333"))).Returns(Task.FromResult(_articleContents[1]));
            _mock.Setup(a => a.GetArticleContentAsync(It.IsIn("232"))).Returns(Task.FromResult(_articleContents[0]));
            ArticleService articleService = new ArticleService(_mock.Object);
            ArticleContentModel articleContent = await articleService.GetArticleContentByIdAsync("333");
            Assert.Equal(_articleContents[1], articleContent);

            articleContent = await articleService.GetArticleContentByIdAsync("232");
            Assert.Equal(_articleContents[0], articleContent);

            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.GetArticleContentByIdAsync(null); });
        }

        [Fact]
        public async void IncViewActionTest()
        {
            _mock.Setup(a => a.IncViewAsync(It.IsIn("333"))).Returns(Task.FromResult(true));
            ArticleService articleService = new ArticleService(_mock.Object);
            bool flag = await articleService.IncViewActionAsync("333");
            Assert.True(flag);

            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.IncViewActionAsync(null); });

        }

        [Fact]
        public async void UpdateArticleTest()
        {
            ArticleInfoModel articleInfoModel = new ArticleInfoModel();
            _mock.Setup(a => a.UpdateArticleAsync(It.Is<ArticleInfoModel>((aim)=> aim.Id != null))).Returns(Task.FromResult(true));
            ArticleService articleService = new ArticleService(_mock.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.UpdateArticleAsync(articleInfoModel); });
            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.UpdateArticleAsync(null); });

            articleInfoModel.Id = "888";
            bool flag = await articleService.UpdateArticleAsync(articleInfoModel);
            Assert.True(flag);
        }

        [Fact]
        public async void AddArticleTest()
        {
            ArticleInfoModel articleInfoModel = new ArticleInfoModel();
            ArticleContentModel articleContentModel = new ArticleContentModel();

            _mock.Setup(a => a.AddArticleAsync(It.Is<ArticleInfoModel>(aim => aim.Id != null))).ReturnsAsync(true);
            _mock.Setup(a => a.AddArticleContentAsync(It.Is<ArticleContentModel>(aim => aim.Id != null))).ReturnsAsync(true);

            ArticleService articleService = new ArticleService(_mock.Object);
            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.AddArticleAsync(null, null); });
            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.AddArticleAsync(articleInfoModel,articleContentModel); });
            articleInfoModel.Id = "111";
            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.AddArticleAsync(articleInfoModel, articleContentModel); });
            articleContentModel.Id = "122";
            await Assert.ThrowsAsync<ApplicationException>(async () => { await articleService.AddArticleAsync(articleInfoModel, articleContentModel); });
            articleContentModel.Id = "111";
            bool flag = await articleService.AddArticleAsync(articleInfoModel, articleContentModel);
            Assert.True(flag);
        }

        [Fact]
        public async void DeleteArticleTest()
        {
            _mock.Setup(a => a.DeleteArticleById(It.IsNotNull<string>())).ReturnsAsync(true);
            ArticleService articleService = new ArticleService(_mock.Object);
            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.DeleteArticleAsync(null); });
            bool flag = await articleService.DeleteArticleAsync("333");
            Assert.True(flag);
        }

        [Fact]
        public async void DecIncLikeTest()
        {
            _mock.Setup(a => a.DecIncLikeAsync(It.IsNotNull<string>(), It.IsAny<bool>())).ReturnsAsync(true);
            ArticleService articleService = new ArticleService(_mock.Object);
            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.DecIncLikeActionAsync(null,true); });
            await Assert.ThrowsAsync<NullReferenceException>(async () => { await articleService.DecIncLikeActionAsync(null, false); });

            bool flag = await articleService.DecIncLikeActionAsync("333",true);
            Assert.True(flag);

            flag = await articleService.DecIncLikeActionAsync("333", false);
            Assert.True(flag);
        }
    }
}
