using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeRecipeEasily.Infrastructure.Migrations
{
    public partial class rename_to_recipesRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesRating_Recipes_RecipeId",
                table: "RecipesRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipesRating",
                table: "RecipesRating");

            migrationBuilder.RenameTable(
                name: "RecipesRating",
                newName: "RecipesRatings");

            migrationBuilder.RenameIndex(
                name: "IX_RecipesRating_RecipeId",
                table: "RecipesRatings",
                newName: "IX_RecipesRatings_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipesRatings",
                table: "RecipesRatings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesRatings_Recipes_RecipeId",
                table: "RecipesRatings",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesRatings_Recipes_RecipeId",
                table: "RecipesRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipesRatings",
                table: "RecipesRatings");

            migrationBuilder.RenameTable(
                name: "RecipesRatings",
                newName: "RecipesRating");

            migrationBuilder.RenameIndex(
                name: "IX_RecipesRatings_RecipeId",
                table: "RecipesRating",
                newName: "IX_RecipesRating_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipesRating",
                table: "RecipesRating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesRating_Recipes_RecipeId",
                table: "RecipesRating",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
