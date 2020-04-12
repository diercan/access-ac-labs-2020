using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;

namespace Domain.Domain.CreateMenuItemOp
{
    class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, ICreateMenuItemResult, Unit> 
    {

        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            var (valid, validationResults) = Op.Validate();

            var priceIsInvalid = !valid ? validationResults.Exists(x => x.MemberNames.Exists(x => x.Equals("Price"))) : false;
            var nameIsInvalid = !valid ? validationResults.Exists(x => x.MemberNames.Exists(x => x.Equals("Name"))) : false;

            if (priceIsInvalid)
                return Task.FromResult((ICreateMenuItemResult)new MenuItemWithInvalidPriceNotCreated($"{Op.Name}'s price should be between 10.0 and 100.0 lei!"));
            else if(nameIsInvalid)
                return Task.FromResult((ICreateMenuItemResult)new MenuItemWithEmptyNameNotCreated($"Menu item name should not be empty!"));

            return Task.FromResult((ICreateMenuItemResult)new MenuItemCreated(new MenuItem(Op.Name, Op.Price)));
        }
    }
}
