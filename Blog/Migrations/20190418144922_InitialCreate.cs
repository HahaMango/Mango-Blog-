using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Userid = table.Column<string>(type: "varchar(12)", nullable: true),
                    Name = table.Column<string>(type: "varchar(10)", nullable: true),
                    DisplayName = table.Column<string>(type: "varchar(10)", nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false)
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
                    PageContentId = table.Column<string>(type: "varchar(12)", nullable: true),
                    PageId = table.Column<string>(type: "varchar(12)", nullable: true),
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
                    PageId = table.Column<string>(type: "varchar(12)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(12)", nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(type: "varchar(120)", nullable: true),
                    Author = table.Column<string>(type: "varchar(30)", nullable: true),
                    Description = table.Column<string>(type: "varchar(120)", nullable: true),
                    Categories = table.Column<string>(type: "varchar(120)", nullable: true),
                    Like = table.Column<int>(nullable: false),
                    Reads = table.Column<int>(nullable: false),
                    Comments = table.Column<int>(nullable: false),
                    WordCount = table.Column<int>(nullable: false),
                    IsOriginal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<string>(type: "varchar(12)", nullable: true),
                    PageId = table.Column<string>(type: "varchar(12)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(12)", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_ArticleContents_PageContentId_PageId",
                table: "ArticleContents",
                columns: new[] { "PageContentId", "PageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PageId",
                table: "Articles",
                column: "PageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "ArticleContents");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
