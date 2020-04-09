using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;


namespace Domain.Domain.CreateIngredientOp
{
    [AsChoice]
    public static partial class CreateIngredientResult
    {
        public interface ICreateIngredientResult { }

        public class IngredientCreated : ICreateIngredientResult
        {
            private string name;

            public Ingredient Ingredient { get; }
            public IngredientCreated(Ingredient ingredient)
            {
                Ingredient = ingredient;
            }

            public IngredientCreated(string name)
            {
                this.name = name;
            }

            public class IngredientNotCreated : ICreateIngredientResult { }
        }

    }
}
