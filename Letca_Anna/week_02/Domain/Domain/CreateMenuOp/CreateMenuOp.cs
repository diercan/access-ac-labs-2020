using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Persistence.EfCore;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;

namespace Domain.Domain.CreateMenuOp
{
    public class CreateMenuOp : OpInterpreter<CreateMenuCmd, ICreateMenuResult, Unit>
    {
        public override Task<ICreateMenuResult> Work(CreateMenuCmd Op, Unit state)
        {
            var (valid, validationResults) = Op.Validate();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage += x.ErrorMessage);

            if (!valid)
                return Task.FromResult((ICreateMenuResult)new MenuNotCreated(validationMessage));

            //Op.RestaurantAgg.Menu = new Menus() { Name = Op.Name, RestaurantId=Op.RestaurantAgg.Restaurant.Id };
            Op.Menu.RestaurantId = (int)Op.RestaurantId;
            return Task.FromResult((ICreateMenuResult)new MenuCreated(Op.Menu));
         }
    }
}
