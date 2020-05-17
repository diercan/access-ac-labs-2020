using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.GetSpecificMenu.GetSpecificMenuResult;

namespace Domain.Domain.GetSpecificMenu
{
    public class GetSpecificMenuOp : OpInterpreter<GetSpecificMenuCmd, IGetSpecificMenuResult, Unit>
    {
        public override Task<IGetSpecificMenuResult> Work(GetSpecificMenuCmd Op, Unit state)
        {
            var (valid, validationResults) = Op.Validate();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage += x.ErrorMessage);

            if (!valid)
                return Task.FromResult<IGetSpecificMenuResult>(new SpecificMenuNotFound(validationMessage));

            Menus foundMenu = Op.Menus.Where(menu => menu.Name.Equals(Op.MenuName)).FirstOrDefault();

            return foundMenu!=null ? 
                Task.FromResult<IGetSpecificMenuResult>(new SpecificMenuFound(foundMenu)) :
                Task.FromResult<IGetSpecificMenuResult>(new SpecificMenuNotFound($"menu {Op.MenuName} not found at {Op.Restaurant.Name}"));
        }
    }
}
