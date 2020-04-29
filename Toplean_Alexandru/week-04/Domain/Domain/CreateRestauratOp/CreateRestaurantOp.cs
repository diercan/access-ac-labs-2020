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

            if (Exists(Op.Name))
            {
                return Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated($"There already is a restaurant with the name {Op.Name}"));
            }
            else
            {
                (bool CommandIsValid, String ErrorCode) = Op.IsValid();

                if (CommandIsValid)
                {
                    RestaurantAgg restaurant = new RestaurantAgg(new Restaurant(Op.Name));
                    //AllHardcodedValues.HarcodedVals.RestaurantList.Add(restaurant);
                    return Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(restaurant));  // Restaurant is valid
                }
                else
                    return Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated(ErrorCode)); // Restaurant is not valid for any reason
            }
        }

        public bool Exists(string name) => false;//AllHardcodedValues.HarcodedVals.Restaurants.Contains(name);
    }
}