using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.PopulateRestaurantOp.PopulateRestaurantResult;

namespace Domain.Domain.PopulateRestaurantOp
{
    internal class PopulateRestaurantOp : OpInterpreter<PopulateRestaurantCmd, IPopulateRestaurantResult, Unit>
    {
        public async override Task<IPopulateRestaurantResult> Work(PopulateRestaurantCmd Op, Unit state)
        {
            try
            {
                var expression = from allMenus in Op.GetAllMenus(Op.RestaurantAgg.Restaurant.Id)
                                 select allMenus;

                var result = await Op.interpreter.Interpret(expression, Unit.Default);

                Op.RestaurantAgg.Menus = Op.RestaurantAgg.Restaurant.Menu = result;

                foreach (var menu in Op.RestaurantAgg.Menus)
                {
                    var expressionMenuItem = from allMenuItems in Op.GetAllMenuItems(menu.Id)
                                             select allMenuItems;

                    var resultMenuItem = await Op.interpreter.Interpret(expressionMenuItem, Unit.Default);
                    menu.MenuItem = resultMenuItem;
                }

                return new RestaurantPopulated(Op.RestaurantAgg);
            }
            catch (Exception exp)
            {
                return new RestaurantNotPopulated(exp.Message);
            }
        }
    }
}