using System;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetAllRestaurantsOp.GetAllRestaurantsResult;

namespace Domain.Domain.GetAllRestaurantsOp
{
    public class GetAllRestaurantsOp : OpInterpreter<GetAllRestaurantsCmd, IGetAllRestaurantsResult, Unit>
    {
        public override Task<IGetAllRestaurantsResult> Work(GetAllRestaurantsCmd Op, Unit state)
        {
            var (valid, validationResults) = Op.Validate();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage += x.ErrorMessage);

            if (!valid)
                return Task.FromResult<IGetAllRestaurantsResult>(new RestaurantsNotFound(validationMessage));
            return Task.FromResult<IGetAllRestaurantsResult>(new RestaurantsFound(Op.Restaurants));
        }
    }
}
