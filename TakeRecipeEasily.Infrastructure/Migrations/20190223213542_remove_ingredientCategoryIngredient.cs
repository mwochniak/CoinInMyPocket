using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeRecipeEasily.Infrastructure.Migrations
{
    public partial class remove_ingredientCategoryIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientCategoriesIngredients");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientCategoryId",
                table: "Ingredients",
                column: "IngredientCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientsCategories_IngredientCategoryId",
                table: "Ingredients",
                column: "IngredientCategoryId",
                principalTable: "IngredientsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientsCategories_IngredientCategoryId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientCategoryId",
                table: "Ingredients");

            migrationBuilder.CreateTable(
                name: "IngredientCategoriesIngredients",
                columns: table => new
                {
                    IngredientCategoryId = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCategoriesIngredients", x => new { x.IngredientCategoryId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_IngredientCategoriesIngredients_IngredientsCategories_IngredientCategoryId",
                        column: x => x.IngredientCategoryId,
                        principalTable: "IngredientsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientCategoriesIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCategoriesIngredients_IngredientId",
                table: "IngredientCategoriesIngredients",
                column: "IngredientId");
        }
    }
}
