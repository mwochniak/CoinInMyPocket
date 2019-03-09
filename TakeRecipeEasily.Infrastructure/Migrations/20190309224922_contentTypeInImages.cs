using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeRecipeEasily.Infrastructure.Migrations
{
    public partial class contentTypeInImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "RecipesImages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "RecipesImages");
        }
    }
}
