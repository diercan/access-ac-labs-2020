using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;

namespace Domain.Domain.CreateMenuItemOp
{
    public class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult, Unit>
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            MenuItem menuItem = new MenuItem(Op.Name, Op.Price, Op.Quantity, Op.Ingredients, Op.Allergens); // Create a new MenuItem       

            if (Op.Menu.MenuItems.Contains(menuItem))   // Verify if there is this menuItem in the MenuItems List from Menu
            {
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated("This menu item already exists!"));
            }
            else
            {
                Op.Menu.MenuItems.Add(menuItem);    // Add this menuItem to MenuItems List from Menu
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(menuItem));
            }
        }
    }
}
