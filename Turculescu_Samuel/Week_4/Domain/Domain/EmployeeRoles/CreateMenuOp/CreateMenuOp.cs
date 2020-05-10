using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.EmployeeRoles.CreateMenuOp.CreateMenuResult;

namespace Domain.Domain.EmployeeRoles.CreateMenuOp
{
    public class CreateMenuOp : OpInterpreter<CreateMenuCmd, ICreateMenuResult, Unit>
    {
        public override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            MenuAgg newMenu = new MenuAgg(new Menu() { Name = Op.Name, RestaurantId = Op.RestaurantId });
            /*if (Exists(Op.Restaurant.Menus, newMenu))
            {
                return Task.FromResult<ICreateMenuResult>(new MenuNotCreated("This menu already exists!"));
            }
            else
            {
                Op.Restaurant.Menus.Add(newMenu);*/
                return Task.FromResult<ICreateMenuResult>(new MenuCreated(newMenu));
            //}
        }

        public bool Exists(List<MenuAgg> Menus, MenuAgg menu)
        {
            if (Menus.Contains(menu))
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