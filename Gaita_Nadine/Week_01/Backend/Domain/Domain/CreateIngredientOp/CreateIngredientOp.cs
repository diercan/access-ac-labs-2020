using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateIngredientOp.CreateIngredientResult;

namespace Domain.Domain.CreateIngredientOp
{
    public class CreateIngredientOp : OpInterpreter<CreateIngredientCmd, ICreateIngredientResult, Unit>
    {
        public override Task<ICreateIngredientResult> Work(CreateIngredientCmd Op, Unit state)
        {
              return Task.FromResult<ICreateIngredientResult>(new IngredientCreated(new Ingredient(Op.Name)));

        }
    }
}
