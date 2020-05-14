using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuOp : OpInterpreter<CreateMenuCmd, ICreateMenuResult, Unit>
    {
        public override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            Menu newMenu = new Menu() { Name = Op.MenuName, RestaurantId = Op.Restaurant.Id };
            //if (Exists(Op.Restaurant, newMenu))
            //{
            //    return Task.FromResult<ICreateMenuResult>(new MenuNotCreated("This menu already exists!"));
            //}
            //else
            //{
                MenuAgg newMenuAgg = new MenuAgg(newMenu);
                return Task.FromResult<ICreateMenuResult>(new MenuCreated(newMenuAgg));
            //}
        }

        public bool Exists(Restaurant restaurant, Menu menu)
        {                
            if (restaurant.Menus.Contains(menu))
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