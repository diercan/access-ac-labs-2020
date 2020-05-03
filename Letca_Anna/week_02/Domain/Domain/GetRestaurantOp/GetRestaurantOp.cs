using System;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantOp : OpInterpreter<GetRestaurantCmd, IGetRestaurantResult, Unit>
    {
        public override Task<IGetRestaurantResult> Work(GetRestaurantCmd Op, Unit state)
        {
            var (valid, validationResults) = Op.Validate();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage += x.ErrorMessage);

            if (!valid)
                return Task.FromResult<IGetRestaurantResult>(new RestaurantNotFound(validationMessage));
            return Task.FromResult<IGetRestaurantResult>(new RestaurantFound(new RestaurantAgg(Op.Restaurant)));
        }
    }
}
