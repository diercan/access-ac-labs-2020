using System;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.GetMenuOp.GetMenuResult;

namespace Domain.Domain.GetMenuOp
{
    public class GetMenuOp : OpInterpreter<GetMenuCmd, IGetMenuResult, Unit>
    {
        public override Task<IGetMenuResult> Work(GetMenuCmd Op, Unit state)
        {
            var (valid, validationResults) = Op.Validate();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage+=x.ErrorMessage);

            if (!valid)
                return Task.FromResult<IGetMenuResult>(new MenuNotFound(validationMessage));

            //Op.RestaurantAgg.Menu = Op.Menu;
            //Op.RestaurantAgg.Menu.MenuItems = Op.MenuItems;
            return Task.FromResult<IGetMenuResult>(new MenuFound(Op.Menus));
        }
    }
}
