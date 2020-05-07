using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;

namespace Domain.Domain.CreateRestauratOp
{
    public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, CreateRestaurantResult.ICreateRestaurantResult, Unit>
    {
        public override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
        {
            //validate

            if (Exists(Op.Restaurant.Name))
            {
                return Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated($"There already is a restaurant with the name {Op.Restaurant.Name}"));
            }
            else
            {
                Restaurant restaurant = Op.Restaurant;
                return Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(new RestaurantAgg(restaurant)));  // Restaurant is valid
            }
        }

        public bool Exists(string name) => false;//AllHardcodedValues.HarcodedVals.Restaurants.Contains(name);
    }
}