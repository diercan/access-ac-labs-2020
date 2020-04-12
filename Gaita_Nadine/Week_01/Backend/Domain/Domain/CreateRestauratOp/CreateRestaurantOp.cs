using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;

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
