using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.EmployeeRoles.CreateMenuItemOp.CreateMenuItemResult;

namespace Domain.Domain.EmployeeRoles.CreateMenuItemOp
{
    public class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult, Unit>
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            MenuItemAgg newMenuItem = new MenuItemAgg(new MenuItem() { Name = Op.Name, Ingredients = Op.Ingredients, Allergens = Op.Allergens, TotalQuantity = Op.TotalQuantity, Price = Op.Price, Availability = Op.Availability, MenuId = Op.MenuId }); // Create a new MenuItem       

            /*if (Exists(Op.Menu, newMenuItem))
            {
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated("This menu item already exists!"));
            }
            else
            {*/
                //Op.MenuAgg.MenuItems.Add(newMenuItem);
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(newMenuItem));
        }

        public bool Exists(MenuAgg menu, MenuItemAgg menuItem)
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
