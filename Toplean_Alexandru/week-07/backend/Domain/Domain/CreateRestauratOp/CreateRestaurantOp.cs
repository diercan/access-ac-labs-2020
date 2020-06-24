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
        public async override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
        {
            return new RestaurantCreated(new RestaurantAgg(Op.Restaurant));  // Restaurant is valid
        }
    }
}