using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuOp : OpInterpreter<CreateMenuCmd, ICreateMenuResult, Unit>
    {
        public override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            var (valid, validationResults) = Op.Validate();

            var restaurantIsInvalid = !valid ? validationResults.Exists(x => x.MemberNames.Exists(x => x.Equals("Restaurant"))) : false;
            var nameIsInvalid = !valid ? validationResults.Exists(x => x.MemberNames.Exists(x => x.Equals("Name"))) : false;

            if (restaurantIsInvalid)
                return Task.FromResult((ICreateMenuResult)new MenuForNullRestaurantNotCreated("can't add menu into a null restaurant!"));
            else if(nameIsInvalid)
                return Task.FromResult((ICreateMenuResult)new ShortNamedMenuNotCreated("menu name should be not empty!"));

            Op.Restaurant.Menu = new Menu(Op.Name, Op.MenuType);
            return Task.FromResult((ICreateMenuResult)new MenuCreated(Op.Restaurant.Menu));
         }
    }
}
