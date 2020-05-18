using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System.Collections.Generic;
using static Domain.Domain.CreateIngredientOp.CreateIngredientResult;

namespace Domain.Domain.CreateIngredientOp
{
    public class CreateIngredientOp : OpInterpreter<CreateIngredientCmd, ICreateIngredientResult, Unit>
    {
        public override Task<ICreateIngredientResult> Work(CreateIngredientCmd Op, Unit state)
        {
            List<Ingredient> ingredients = new List<Ingredient>(Op.NoIngredients);

            for(int i=0; i<Op.NoIngredients; i++)
            {
                Ingredient ingredient = new Ingredient(Op.Ingredients[i]);

                ingredients.Add(ingredient);
            }  
            return Task.FromResult<ICreateIngredientResult>(new IngredientCreated(ingredients));

        }
    }
}
