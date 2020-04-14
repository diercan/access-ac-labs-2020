using Infrastructure.Free;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;

namespace Domain.Domain.CreateMenuItemOp
{
    public class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult, Unit>
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            //validate

            //invalid price
            if (Op.Price < 0)
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated("The menu item " + Op.Name + " has invalid price."));
            
            return !Exists(Op.Name) ?
                //the item menu already exists
                Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated("The menu item already exists.")) :
                Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(new MenuItem(Op.Menu, Op.Name, Op.Ingredients, Op.Price)));
        }


        public bool Exists(string name)
        {
            return true;
        }
    }
}
