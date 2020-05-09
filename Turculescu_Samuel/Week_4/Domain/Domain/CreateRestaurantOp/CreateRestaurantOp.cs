using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.CreateRestaurantOp.CreateRestaurantResult;

namespace Domain.Domain.CreateRestaurantOp
{
    public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, CreateRestaurantResult.ICreateRestaurantResult, Unit>
    {
        private List<Restaurant>.Enumerator r = App.RestaurantsList.GetEnumerator();    // r is enumerator for RestaurantsList

        public override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
        {
            // Validate

            if(Exists(Op.Name))
            {
                return Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated("Restaurant already exists!"));
            }
            else
            {
                RestaurantAgg newRestaurant = new RestaurantAgg(new Restaurant() { Name = Op.Name , Address = Op.Address});
                return Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(newRestaurant));
            }                             
        }


        public bool Exists(string restaurantName)
        {                    
            while (r.MoveNext())
            {
                if (restaurantName == r.Current.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
