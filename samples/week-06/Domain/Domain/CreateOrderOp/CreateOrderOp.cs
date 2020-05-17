using System;
using System.Net;
using System.Net.Http;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Persistence.EfCore;
using System.Threading.Tasks;
using EarlyPay.Primitives.Mocking;
using Microsoft.Extensions.DependencyInjection;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    public partial class CreateOrderOp : OpInterpreter<CreateOrderCmd, ICreateOrderResult, Unit>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IExecutionContext _ex;

        public CreateOrderOp(IServiceProvider serviceProvider, IExecutionContext ex)
        {
            _serviceProvider = serviceProvider;
            _ex = ex;
        }

        public override async Task<ICreateOrderResult> Work(CreateOrderCmd Op, Unit state)
        {
            (bool CommandIsValid, string ErrorCode) = Op.IsValid();

            if (CommandIsValid)
            {
                Order order = new Order(Op.ClientId, Op.RestaurantId, Op.TableNumber, Op.TotalPrice, Op.Status, Op.PaymentStatus);

                var httpResponseMessage = await _ex.Effect(PaymentEffect.Accepted, ExecutePayment, Op.TotalPrice);

                switch (httpResponseMessage.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return new OrderCreated(new OrderAgg(order)); // Order successfully created
                    default:
                        return new OrderNotCreated(string.Empty);
                } 
            }
            else
            {
                return new InvalidRequest(Op);
            }
        }

        private async Task<HttpResponseMessage> ExecutePayment(double totalPrice)
        {
            var paymentService = _serviceProvider.GetService<IPaymentService>();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public enum PaymentEffect
        {
            Accepted, 
            Rejected,
            Exception
        }
    }

    internal interface IPaymentService
    {
    }
}