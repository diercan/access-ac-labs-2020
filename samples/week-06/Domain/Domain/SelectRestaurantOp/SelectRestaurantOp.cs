using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;

namespace Domain.Domain.SelectRestaurantOp
{
    public class SelectRestaurantOp : OpInterpreter<SelectRestaurantCmd, ISelectRestaurantResult, Unit>
    {
        public override Task<ISelectRestaurantResult> Work(SelectRestaurantCmd Op, Unit state)
        {
            try
            {
                Op.CheckIfValid();

                return Task.FromResult<ISelectRestaurantResult>(new RestaurantSelected(new RestaurantAgg(Op.Restaurant)));
            }
            catch (Exception exp)
            {
                return Task.FromResult<ISelectRestaurantResult>(new RestaurantNotSelected(exp.Message));
            }
        }
    }
}