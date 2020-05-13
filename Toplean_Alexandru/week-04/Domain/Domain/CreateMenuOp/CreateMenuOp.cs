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
        public async override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            Menu menu = Op.Menu;
            menu.RestaurantId = Op.Restaurant.Id;
            return new MenuCreated(new MenuAgg(menu)); // Creates the menu
        }
    }
}