using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Queries;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence;
using Persistence.EfCore;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;

namespace Domain.Domain.CreateRestauratOp
{
    public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, CreateRestaurantResult.ICreateRestaurantResult, Unit>
    {
        private readonly LiveInterpreterAsync interpreter;

        public CreateRestaurantOp(LiveInterpreterAsync interpreter)
        {
            this.interpreter = interpreter;
        }

        public async override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
        {
            var sth = Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(Op.Restaurant.Name));
            var result = await interpreter.Interpret(sth, Unit.Default);

            if (result == null)
            {
                Restaurant restaurant = Op.Restaurant;
                return new RestaurantCreated(new RestaurantAgg(restaurant));  // Restaurant is valid
            }
            else
            {
                return new RestaurantNotCreated("Exists");  // Restaurant is valid
            }
        }
    }
}