using System.Collections.Generic;

namespace Domain.Domain.CreateIngredientOp
{
    public struct CreateIngredientCmd
    {
        public ushort NoIngredients { get; }

        public List<string> Ingredients { get; }
        public CreateIngredientCmd(ushort noIngredients, List<string> ingredients)
        {
            NoIngredients = noIngredients;
            Ingredients = new List<string>(NoIngredients);
            Ingredients = ingredients;
        }
    }
}
