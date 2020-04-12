using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;

namespace Domain.Domain.CreateRestauratOp
{
    public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, CreateRestaurantResult.ICreateRestaurantResult, Unit>
    {
        public override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
        {
            if (!Op.Validate().Item1)
                return Task.FromResult<ICreateRestaurantResult>(new EmptyNameRestaurantNotCreated("Cant create an empty name restaurant!"));

            return Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(new Restaurant(Op.Name)));
        }
    }
}
