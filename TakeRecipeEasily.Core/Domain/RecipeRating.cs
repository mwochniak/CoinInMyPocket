using System;

namespace TakeRecipeEasily.Core.Domain
{
    public sealed class RecipeRating : Entity
    {
        public int Rate { get; private set; }
        public Guid RecipeId { get; private set; }
        public Guid UserId { get; private set; }
        public string Comment { get; private set; }

        public Recipe Recipe { get; private set; }
        public User User { get; private set; }

        private RecipeRating() { }

        private RecipeRating(Guid id, int rate, Guid recipeId, Guid userId, string comment)
        {
            Id = id;
            Rate = rate;
            RecipeId = recipeId;
            UserId = userId;
            Comment = comment;
        }

        public static RecipeRating Create(Guid id, int rate, Guid recipeId, Guid userId, string comment)
            => new RecipeRating(id: id, rate: rate, recipeId: recipeId, userId: userId, comment: comment);

        public void Update(int rate, string comment)
        {
            Rate = rate;
            Comment = comment;
        }
    }
}
