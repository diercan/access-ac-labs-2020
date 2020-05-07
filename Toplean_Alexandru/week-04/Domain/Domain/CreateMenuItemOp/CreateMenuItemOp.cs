using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;

namespace Domain.Domain.CreateMenuItemOp
{
    public class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, ICreateMenuItemResult, Unit>
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            try
            {
                //MenuItem menuItem = new MenuItem(Op.MenuID, Op.Name, Op.Ingredients, Op.Alergens, Op.Price, Op.Image);
                MenuItemAgg menuItemAgg = new MenuItemAgg(Op.MenuItem);
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(menuItemAgg));  // Restaurant is valid
            }
            catch (Exception exp)
            {
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated(exp.Message));  // Restaurant is not valid
            }
        }
    }
}