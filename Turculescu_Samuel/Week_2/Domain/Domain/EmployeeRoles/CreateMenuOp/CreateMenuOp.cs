using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.EmployeeRoles.CreateMenuOp.CreateMenuResult;

namespace Domain.Domain.EmployeeRoles.CreateMenuOp
{
    public class CreateMenuOp : OpInterpreter<CreateMenuCmd, ICreateMenuResult, Unit>
    {
        public override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            Menu newMenu = new Menu(Op.MenuName);
            if (Exists(Op.Restaurant.Menus, newMenu))
            {
                return Task.FromResult<ICreateMenuResult>(new MenuNotCreated("This menu already exists!"));
            }
            else
            {
                Op.Restaurant.Menus.Add(newMenu);
                return Task.FromResult<ICreateMenuResult>(new MenuCreated(newMenu));
            }
        }

        public bool Exists(List<Menu> Menus, Menu menu)
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