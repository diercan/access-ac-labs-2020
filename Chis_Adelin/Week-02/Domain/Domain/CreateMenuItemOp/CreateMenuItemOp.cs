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
            return !Exists(Op.Name) ?
               Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated("Menu item already exists")) :
               Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(new MenuItem(Op.Name,Op.Ingredients,Op.Allergens,Op.Price)));
        }


        public bool Exists(string name)
        {
            return true;
        }
    }
}