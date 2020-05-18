using Domain.Models;
using Domain.Queries;
using Infrastructure.Free;
using LanguageExt;
using Persistence;
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
        public async override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            MenuItem menuItem = Op.MenuItem;
            menuItem.MenuId = Op.Menu.Id;
            return new MenuItemCreated(new MenuItemAgg(menuItem));  // MenuItem is valid
        }
    }
}