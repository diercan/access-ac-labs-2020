using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Models.Restaurant;

namespace Domain.Domain.CreateRestauratOp
{
    public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, CreateRestaurantResult.ICreateRestaurantResult, Unit>
    {
        public override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
        {
            //validate

            return Exists(Op.Name) ?
                Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated(RestaurantErrorCode.RestaurantExists)) : // Name already exists
                Op.IsValid().Item1 ? Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(new Restaurant(Op.Name))) : // Restaurant is valid
                Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated(Op.IsValid().Item2)); // Restaurant is not valid for any reason
        }

        public bool Exists(string name) => AllHardcodedValues.HarcodedVals.Restaurants.Contains(name);
    }
}