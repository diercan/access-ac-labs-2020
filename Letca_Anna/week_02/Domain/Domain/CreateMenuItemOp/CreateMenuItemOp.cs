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
            var (valid, validationMessage) = Op.Validate();

            if (!valid)
                return Task.FromResult((ICreateMenuItemResult)new MenuItemNotCreated(validationMessage));

            return Task.FromResult((ICreateMenuItemResult)new MenuItemCreated(new MenuItem(Op.Name, Op.Price)));
        }
    }
}
