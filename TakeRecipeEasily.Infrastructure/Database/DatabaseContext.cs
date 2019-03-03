using TakeRecipeEasily.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TakeRecipeEasily.Infrastructure.SQL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientCategory> IngredientsCategories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipesIngredients { get; set; }
        public DbSet<RecipeImage> RecipesImages { get; set; }
        public DbSet<RecipeRating> RecipesRatings { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(
            DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasOne(i => i.IngredientCategory).WithMany(ic => ic.Ingredients).HasForeignKey(i => i.IngredientCategoryId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recipe>().HasMany(r => r.RecipeRatings).WithOne(rr => rr.Recipe).HasForeignKey(rr => rr.RecipeId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecipeIngredient>().HasKey(ri => new { ri.RecipeId, ri.IngredientId });
            modelBuilder.Entity<RecipeIngredient>().HasOne(ri => ri.Ingredient).WithMany(i => i.RecipesIngredients).HasForeignKey(ri => ri.IngredientId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RecipeIngredient>().HasOne(ri => ri.Recipe).WithMany(r => r.RecipeIngredients).HasForeignKey(ri => ri.RecipeId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecipeImage>().HasOne(ri => ri.Recipe).WithMany(r => r.RecipeImages).HasForeignKey(ri => ri.RecipeId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasMany(u => u.Recipes).WithOne(r => r.User).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecipeRating>().HasOne(rr => rr.User).WithMany(u => u.RecipesRatings).HasForeignKey(rr => rr.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
