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
using static Domain.Domain.CreateMenuOp.CreateMenuResult;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuOp : OpInterpreter<CreateMenuCmd, ICreateMenuResult, Unit>
    {
        private readonly LiveInterpreterAsync interpreter;

        public CreateMenuOp(LiveInterpreterAsync interpret)
        {
            interpreter = interpret;
        }

        public async override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            var menuQuery = await interpreter.Interpret(Database.Query<GetMenuQuery, Menu>(new GetMenuQuery(Op.Menu.Name, Op.Menu.RestaurantId)), Unit.Default);

            if (menuQuery == null)
            {
                MenuAgg menu = new MenuAgg(Op.Menu);
                return new MenuCreated(menu); // Creates the menu
            }
            else
            {
                return new MenuNotCreated("The menu already exists for this restaurant");
            }
        }
    }
}