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
        private readonly LiveInterpreterAsync interpreter;

        public CreateMenuItemOp(LiveInterpreterAsync interpreter)
        {
            this.interpreter = interpreter;
        }

        public async override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            try
            {
                var query = await interpreter.Interpret(Database.Query<GetMenuItemQuery, MenuItem>(new GetMenuItemQuery(Op.MenuItem.Name, Op.MenuItem.MenuId)), Unit.Default);

                if (query == null)
                {
                    MenuItemAgg menuItemAgg = new MenuItemAgg(Op.MenuItem);
                    return new MenuItemCreated(menuItemAgg);  // Restaurant is valid
                }
                else
                {
                    return new MenuItemNotCreated("This menu item already exists");
                }
            }
            catch (Exception exp)
            {
                return new MenuItemNotCreated(exp.Message);  // Restaurant is not valid
            }
        }
    }
}