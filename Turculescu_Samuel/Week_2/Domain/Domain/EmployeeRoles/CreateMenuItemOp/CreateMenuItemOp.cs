using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.EmployeeRoles.CreateMenuItemOp.CreateMenuItemResult;

namespace Domain.Domain.EmployeeRoles.CreateMenuItemOp
{
    public class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult, Unit>
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            MenuItem newMenuItem = new MenuItem(Op.Name, Op.Price, Op.Quantity, Op.Ingredients, Op.Allergens, Op.MenuItemState); // Create a new MenuItem       

            if (Exists(Op.Menu, newMenuItem))
            {
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated("This menu item already exists!"));
            }
            else
            {
                Op.Menu.MenuItems.Add(newMenuItem);
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(newMenuItem));
            }
        }

        public bool Exists(Menu menu, MenuItem menuItem)
        {
            if (menu.MenuItems.Contains(menuItem))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
