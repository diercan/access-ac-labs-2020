using CSharp.Choices.Attributes;
using Domain.Models;

namespace Domain.Domain.CreateIngredientOp
{
    [AsChoice]
    public static partial class CreateIngredientResult
    {
        public interface ICreateIngredientResult { };
        public class IngredientCreated : ICreateIngredientResult
        {
            public Ingredient Ingredient { get; }
            public IngredientCreated(Ingredient ingredient)
            {
                Ingredient = ingredient;
            }

        }

        public class IngredientNotCreated : ICreateIngredientResult
        {
            public string Reason;
            public IngredientNotCreated(string reason) {
                Reason = reason;
            }
        }

    }
}
