using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;

namespace Domain.Domain.CreateMenuItemOp
{
    public class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult, Unit>
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            MenuItem newMenuItem = new MenuItem() { Name = Op.Name, Ingredients = Op.Ingredients, Allergens = Op.Allergens, TotalQuantity = Op.TotalQuantity, Price = Op.Price, Availability = Op.Availability, MenuId = Op.Menu.Id }; // Create a new MenuItem       

            //if (Exists(Op.Menu, newMenuItem))
            //{
            //    return Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated($"This menu item already exists in Menu: {Op.Menu.Id}, Restaurant: {Op.Menu.RestaurantId}!"));
            //}
            //else
            //{
                MenuItemAgg newMenuItemAgg = new MenuItemAgg(newMenuItem);
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(newMenuItemAgg));
            //}
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
