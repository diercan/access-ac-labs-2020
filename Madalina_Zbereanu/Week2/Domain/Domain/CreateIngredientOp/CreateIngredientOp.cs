using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.CreateIngredientOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;

using static Domain.Domain.CreateIngredientOp.CreateIngredientResult;
using static Domain.Models.Ingredient;

namespace Domain.Domain.CreateIngredientOp
{
    public class CreateIngredientOp : OpInterpreter<CreateIngredientCmd, ICreateIngredientResult, Unit>
    {

        public override Task<ICreateIngredientResult> Work(CreateIngredientCmd Op, Unit state)
        {

            return !Exists(Op.Name) ? 
                Task.FromResult((ICreateIngredientResult)new IngredientCreated("The ingredient already exists")) :
                Task.FromResult((ICreateIngredientResult)new IngredientCreated(Op.Name));
        }
        public bool Exists(string name)
        {
            return true;
        }
    }
}
