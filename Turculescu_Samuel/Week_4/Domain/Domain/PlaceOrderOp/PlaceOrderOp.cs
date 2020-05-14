using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.PlaceOrderOp.PlaceOrderResult;

namespace Domain.Domain.PlaceOrderOp
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
                DateTime dateTime = DateTime.Now;
                TimeSpan preparationTime = new TimeSpan(0, 0, 0);                
                Order newOrder = new Order { ClientId = Op.Client.Id, RestaurantId = Op.Restaurant.Id, TableNumber = Op.TableNumber, DateTimePlaced = dateTime, TotalPrice = Op.TotalPrice, OrderStatus = "Processing", PreparationTime = preparationTime, PaymentStatus = "Unpaid" };
                return Task.FromResult<IPlaceOrderResult>(new OrderPlaced(new OrderAgg(newOrder)));
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
