using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
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
            //validate
            if(Op.Price < 0)
            {
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated("price cannot be negative"));
            }

            return !Exists(Op.Name) ?
            Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated("Menu item exists!")) :
            Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(new MenuItem(Op.Menu, Op.Name, Op.Price, Op.Ingredients)));
        }

        public bool Exists(string name)
        {
            return true;
        }
    }
 }
