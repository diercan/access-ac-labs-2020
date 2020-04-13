using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateMenuItem.CreateMenuItemResult;

namespace Domain.Domain.CreateMenuItem
{
    internal class CreateMenuItemOp : OpInterpreter<CreateMenuItemCmd, ICreateMenuItemResult, Unit>
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemCmd Op, Unit state)
        {
            (bool Valid, String ErrorMessage) = Op.IsValid();

            if (Valid)
            {
                MenuItem item = new MenuItem(Op.Name, Op.Price, Op.Alergens, Op.Ingredients, Op.ImageData);
                Op.Menu.Items.Add(item);
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(item));
            }
            else
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated(ErrorMessage));
        }
    }
}