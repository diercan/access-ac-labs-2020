using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateRestaurantOp.CreateRestaurantResult;

namespace Domain.Domain.CreateRestaurantOp
{
    public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, CreateRestaurantResult.ICreateRestaurantResult, Unit>
    {
        public override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
        {
            // Validate

            return !Exists(Op.Name) ? 
                Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated("Restaurant already exists!")) : 
                Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(new Restaurant(Op.Name, Op.Address)));
        }


        public bool Exists(string name)
        {
            return true;
        }
    }
}
