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

        public CreateOrderOp(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            // _ex = ex;
        }

        public override async Task<ICreateOrderResult> Work(CreateOrderCmd Op, Unit state)
        {
            try
            {
                // await _ex.Effect(OrderEffect.Good, CreateOrder, Op.Order);

                (bool CommandIsValid, string ErrorCode) = Op.IsValid();

                if (CommandIsValid)
                {
                    //var httpResponseMessage = await _ex.Effect(PaymentEffect.Accepted, ExecutePayment, Op.Order.TotalPrice);

                    return new OrderCreated(new OrderAgg(Op.Order)); // Order successfully created
                }
                else
                {
                    return new InvalidRequest(Op);
                }
            }
            catch
            {
                return new InvalidRequest(Op);
            }
        }

        private async Task<ICreateOrderResult> CreateOrder(Order order)
        {
            return new OrderCreated(new OrderAgg(order));
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

        public enum OrderEffect
        {
            Good,
            Invalid,
            Exception
        }
    }

    internal interface IPaymentService
    {
    }
}