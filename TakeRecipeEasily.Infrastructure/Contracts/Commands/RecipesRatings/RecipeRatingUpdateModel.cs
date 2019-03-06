using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings
{
    public sealed class RecipeRatingUpdateModel
    {
        public Guid Id { get; }
        public int Rate { get; }
        public string Comment { get; }

        private RecipeRatingUpdateModel(Guid id, int rate, string comment)
        {
            Id = id;
            Rate = rate;
            Comment = comment;
        }

        public static RecipeRatingUpdateModel Create(Guid id, int rate, string comment)
            => new RecipeRatingUpdateModel(id: id, rate: rate, comment: comment);
    }
}
