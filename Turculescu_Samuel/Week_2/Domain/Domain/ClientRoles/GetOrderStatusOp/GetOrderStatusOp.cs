using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.ClientRoles.GetOrderStatusOp.GetOrderStatusResult;

namespace Domain.Domain.ClientRoles.GetOrderStatusOp
{
    public class GetOrderStatusOp : OpInterpreter<GetOrderStatusCmd, GetOrderStatusResult.IGetOrderStatusResult, Unit>
    {
        public override Task<IGetOrderStatusResult> Work(GetOrderStatusCmd Op, Unit state)
        {
            return (Done(Op.Order.PreparationTimeInMinutes)) ?
                Task.FromResult<IGetOrderStatusResult>(new OrderStatus("Order is done!")) :
                Task.FromResult<IGetOrderStatusResult>(new OrderStatus($"Order is processing! Preparation time: {Op.Order.PreparationTimeInMinutes}"));

        }

        public bool Done(uint preparationTimeInMinutes)
        {
            if(preparationTimeInMinutes == 0)   // If preparationTimeInMinutes is 0 means that the order is ready for serving
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
