using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetOrderStatusOp.GetOrderStatusResult;

namespace Domain.Domain.GetOrderStatusOp
{
    public class GetOrderStatusOp : OpInterpreter<GetOrderStatusCmd, GetOrderStatusResult.IGetOrderStatusResult, Unit>
    {
        public override Task<IGetOrderStatusResult> Work(GetOrderStatusCmd Op, Unit state)
        {
            if(Done(Op.Order.PreparationTime))
            {
                Op.Order.OrderStatus = "Done";
                return Task.FromResult<IGetOrderStatusResult>(new GetOrderStatus($"Order is {Op.Order.OrderStatus}!"));
            }
            else
            {
                return Task.FromResult<IGetOrderStatusResult>(new GetOrderStatus($"Order is {Op.Order.OrderStatus}! Preparation time: {Op.Order.PreparationTime}"));
            }
        }

        public bool Done(TimeSpan preparationTime)
        {
            TimeSpan finishTime = new TimeSpan(0, 0, 0);
            if (preparationTime == finishTime)   // If preparationTimeInMinutes is 0 means that the order is ready for serving
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
