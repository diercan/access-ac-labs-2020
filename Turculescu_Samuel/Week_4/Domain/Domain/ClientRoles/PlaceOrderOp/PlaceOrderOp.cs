using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.ClientRoles.PlaceOrderOp.PlaceOrderResult;

namespace Domain.Domain.ClientRoles.PlaceOrderOp
{
    public class PlaceOrderOp : OpInterpreter<PlaceOrderCmd, PlaceOrderResult.IPlaceOrderResult, Unit>
    {
        public override Task<IPlaceOrderResult> Work(PlaceOrderCmd Op, Unit state)
        {            
            if(!Exists(Op.TableNumber))
            {
                return Task.FromResult<IPlaceOrderResult>(new OrderNotPlaced("Please enter your table number!"));
            }
            else
            {
                Order Order = new Order(Op.Restaurant.OrderId++, Op.Client.Id, Op.TableNumber, OrderStatus.Processing);
                Op.Restaurant.OrdersList.Add(Order);
                return Task.FromResult<IPlaceOrderResult>(new OrderPlaced(Order));
            }        
        }

        public bool Exists(uint tableNumber)
        {
            if(tableNumber > 0)
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
