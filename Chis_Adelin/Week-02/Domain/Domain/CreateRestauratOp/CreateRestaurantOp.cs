using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using System.Threading.Tasks;

namespace Domain.Domain.CreateRestauratOp
{
    public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, CreateRestaurantResult.ICreateRestaurantResult, Unit>
    {
        public override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
        {
            //validate

            return !Exists(Op.Name) ? 
                Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated("restaurant already exists")) : 
                Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(new Restaurant(Op.Name)));
        }
        public bool Exists(string name)
        {
            return true;
        }
    }
}
