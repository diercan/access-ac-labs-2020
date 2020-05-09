using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Domain.CreateIngredientOp
{
    [AsChoice]
    public static partial class CreateIngredientResult
    {
        public interface ICreateIngredientResult { };
        public class IngredientCreated : ICreateIngredientResult
        {
            public List<Ingredient> Ingredients { get; }
            public IngredientCreated(List<Ingredient> ingredients)
            {
                Ingredients = ingredients;
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
