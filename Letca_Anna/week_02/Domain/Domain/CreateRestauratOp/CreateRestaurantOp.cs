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
    public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, ICreateRestaurantResult, Unit>
    {
        public override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
        {
            var (valid, validationMessage) = Op.Validate();

            if (!valid)
                return Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated(validationMessage));

            Restaurant newRestaurant = new Restaurant(Op.Name);
            Storage.RestaurantCollection[newRestaurant.Name] = newRestaurant;
            return Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(newRestaurant));
        }
    }
}
