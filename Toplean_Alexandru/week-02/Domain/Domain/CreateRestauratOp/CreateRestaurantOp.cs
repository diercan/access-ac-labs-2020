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
                Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated(RestaurantErrorCode.RestaurantExists)) :
                HasIllegalCharacters(Op.Name) ? Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated(RestaurantErrorCode.IllegalCharacters)) :
                NameTooLong(Op.Name) ? Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated(RestaurantErrorCode.NameTooLong)) :
                NameTooShort(Op.Name) ? Task.FromResult<ICreateRestaurantResult>(new RestaurantNotCreated(RestaurantErrorCode.EmptyField)) :
                Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(new Restaurant(Op.Name)));
        }

        public bool Exists(string name) => AllHardcodedValues.HarcodedVals.Restaurants.Contains(name);

        public bool NameTooLong(String name) => name.Length > 256 ? true : false;

        public bool NameTooShort(String name) => name.Length > 0 ? false : true;

        public bool HasIllegalCharacters(String name)
        {
            foreach (char c in name)
            {
                if ((int)c < 0x20 || (int)c > 0x7E)
                    return true;
            }
            return false;
        }
    }
}