using TakeRecipeEasily.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace TakeRecipeEasily.Infrastructure.SQL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientCategory> IngredientsCategories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipesIngredients { get; set; }
        public DbSet<RecipeRating> RecipesRatings { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(
            DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>().HasKey(ri => new { ri.RecipeId, ri.IngredientId });
            modelBuilder.Entity<RecipeIngredient>().HasOne(ri => ri.Ingredient).WithMany(i => i.RecipesIngredients).HasForeignKey(ri => ri.IngredientId);
            modelBuilder.Entity<RecipeIngredient>().HasOne(ri => ri.Recipe).WithMany(r => r.RecipesIngredients).HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<Ingredient>().HasOne(i => i.IngredientCategory).WithMany(ic => ic.Ingredients).HasForeignKey(i => i.IngredientCategoryId);

            modelBuilder.Entity<User>().HasMany(u => u.Recipes).WithOne(r => r.User).HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Recipe>().HasOne(r => r.RecipeRating).WithOne(rr => rr.Recipe).HasForeignKey<RecipeRating>(rr => rr.RecipeId);
        }
    }
}
