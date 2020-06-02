using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.PopulateOrderOp.PopulateOrderResult;

namespace Domain.Domain.PopulateOrderOp
{
    public class PopulateOrderOp : OpInterpreter<PopulateOrderCmd, IPopulateOrderResult, Unit>
    {
        public async override Task<IPopulateOrderResult> Work(PopulateOrderCmd Op, Unit state)
        {
            try
            {
                var expression = from allOrders in Op.GetAllOrders(Op.Restaurant.Id)
                                 select allOrders;

                var result = await Op.interpreter.Interpret(expression, Unit.Default);

                Op.Restaurant.Order = result;

                foreach (var order in Op.Restaurant.Order)
                {
                    var getOrderItemsExpression = from allOrderItems in Op.GetAllOrderItems(order.Id)
                                                  select allOrderItems;

                    order.OrderItems = await Op.interpreter.Interpret(getOrderItemsExpression, Unit.Default);
                }

                return new OrderPopulated(Op.Restaurant.Order);
            }
            catch (Exception exp)
            {
                return new OrderNotPopulated(exp.Message);
            }
        }
    }
}