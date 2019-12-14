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

namespace MangoBlogTest
{
    public class ArticleServiceTest
    {
        private readonly IList<ArticleInfoModel> _infoList = null;
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

            _mock = new Mock<IArticleDao>();
        }

        [Fact]
        public async void ArticleCount()
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
    }
}
