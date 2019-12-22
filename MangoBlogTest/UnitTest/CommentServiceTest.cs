using MangoBlog.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MangoBlog.Service;
using MangoBlog.Service.Imp;

namespace MangoBlogTest.UnitTest
{
    public class CommentServiceTest
    {
        //articleId = 213
        private readonly IList<CommentModel> _page1Comment = null;

        //articleId = 333
        private readonly IList<CommentModel> _page2Comment = null;

        private readonly Mock<ICommentService> _mock = null;

        public CommentServiceTest()
        {
            _page1Comment = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = "122",
                    UserName = "user3",
                    Comment = "comment3",
                    Date = new DateTime(2019,12,4)
                },
                new CommentModel
                {
                    Id = "144",
                    UserName = "user1",
                    Comment = "comment1",
                    Date = new DateTime(2018,2,4)
                },
                new CommentModel
                {
                    Id = "432",
                    UserName = "user2",
                    Comment = "comment2",
                    Date = new DateTime(2019,6,1)
                }
            };

            _page2Comment = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = "657",
                    UserName = "user8",
                    Comment = "comment8",
                    Date = new DateTime(2019,2,4)
                },
                new CommentModel
                {
                    Id = "232",
                    UserName = "user7",
                    Comment = "comment7",
                    Date = new DateTime(2017,2,4)
                },
                new CommentModel
                {
                    Id = "112",
                    UserName = "user5",
                    Comment = "comment5",
                    Date = new DateTime(2019,1,1)
                }
            };

            _mock = new Mock<ICommentService>();
        }

        [Fact]
        public async void GetCommentByArticleIdTest()
        {
            CommentService commentService = new CommentService(_mock.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () => { await commentService.GetCommentsAsync(null, 0, 10); });
            var result = await commentService.GetCommentsAsync("213", 0, 10);
            Assert.Equal(_page1Comment, result);

            result = await commentService.GetCommentsAsync("213", 1, 1);
            Assert.Equal(
                new List<CommentModel>
                {
                    _page1Comment[1]
                }, 
                result);

            result = await commentService.GetCommentsAsync("213", 1, 2);
            Assert.Equal(
                new List<CommentModel>
                {
                    _page1Comment[1],
                    _page1Comment[2]
                },
                result);

            result = await commentService.GetCommentsAsync("345", 0, 5);
            Assert.Equal(
                new List<CommentModel>
                {
                },
                result);
        }

        [Fact]
        public async void GetCommentByIdTest()
        {

        }

        [Fact]
        public async void ReplyCommentTest()
        {

        }

        [Fact]
        public async void DeleteCommentTest()
        {

        }
    }
}
