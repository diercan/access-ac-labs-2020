using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetMenuItemResult.MenuItemResult;

namespace Domain.Domain.GetMenuItemOp
{
    public class GetMenuItemOp : OpInterpreter<GetMenuItemCmd, IGetMenuItemResult, Unit>
    {
        public override Task<IGetMenuItemResult> Work(GetMenuItemCmd Op, Unit state)
        {
            var (valid, validationResults) = Op.Validate();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage += x.ErrorMessage);

            if (!valid)
                return Task.FromResult<IGetMenuItemResult>(new MenuItemNotFound(validationMessage));

            if (!Op.Menu.MenuItems.Any(x=>x.Name == Op.ItemName))
                return Task.FromResult<IGetMenuItemResult>(new MenuItemNotFound($"{Op.Menu} has no item called {Op.ItemName}!"));

            return Task.FromResult<IGetMenuItemResult>(new MenuItemFound(Op.Menu.MenuItems.Find(x => x.Name == Op.ItemName)));
        }
    }
}