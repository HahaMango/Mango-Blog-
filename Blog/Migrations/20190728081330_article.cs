using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Userid = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(10)", nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    ArticleCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(type: "varchar(120)", nullable: true),
                    Author = table.Column<string>(type: "varchar(30)", nullable: true),
                    Description = table.Column<string>(type: "varchar(120)", nullable: true),
                    Categories = table.Column<string>(type: "varchar(120)", nullable: true),
                    IsOriginal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.UniqueConstraint("AK_Articles_PageId", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "CommandPages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CommandId = table.Column<int>(nullable: false),
                    PageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CommandId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ReplyComId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Like = table.Column<int>(nullable: false),
                    IsReply = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserArticleAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    TotalLike = table.Column<int>(nullable: false),
                    TotalComment = table.Column<int>(nullable: false),
                    TotalRead = table.Column<int>(nullable: false),
                    TotalArticle = table.Column<int>(nullable: false),
                    TotalOriginal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserArticleAnalyses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    Like = table.Column<int>(nullable: false),
                    Reads = table.Column<int>(nullable: false),
                    Comments = table.Column<int>(nullable: false),
                    WordCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleStatistics_Articles_PageId",
                        column: x => x.PageId,
                        principalTable: "Articles",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleContents_PageId",
                table: "ArticleContents",
                column: "PageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreateTime",
                table: "Articles",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PageId",
                table: "Articles",
                column: "PageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStatistics_Like",
                table: "ArticleStatistics",
                column: "Like");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStatistics_PageId",
                table: "ArticleStatistics",
                column: "PageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommandPages_CommandId",
                table: "CommandPages",
                column: "CommandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommandUsers_CommandId",
                table: "CommandUsers",
                column: "CommandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserArticleAnalyses_UserId",
                table: "UserArticleAnalyses",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "ArticleContents");

            migrationBuilder.DropTable(
                name: "ArticleStatistics");

            migrationBuilder.DropTable(
                name: "CommandPages");

            migrationBuilder.DropTable(
                name: "CommandUsers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UserArticleAnalyses");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
