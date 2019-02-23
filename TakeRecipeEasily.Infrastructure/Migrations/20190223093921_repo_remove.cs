using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeRecipeEasily.Infrastructure.Migrations
{
    public partial class repo_remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IngredientCategoryId",
                table: "Ingredients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientCategoryId",
                table: "Ingredients");
        }
    }
}
