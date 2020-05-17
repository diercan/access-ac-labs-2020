using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EarlyPay.Primitives.Mocking;
using LanguageExt;
using Persistence.EfCore;
using Xunit;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    public partial class CreateOrderOp
    {
        public override void RegisterMocks(IMockableContext executionContext)
        {
            executionContext.Mock<PaymentEffect, double, Task<HttpResponseMessage>>(PaymentEffect.Accepted, PaymentAcceptedEffect);
            executionContext.Mock<PaymentEffect, double, Task<HttpResponseMessage>>(PaymentEffect.Rejected, PaymentRejectedEffect);
            executionContext.Mock<PaymentEffect, double, Task<HttpResponseMessage>>(PaymentEffect.Exception, PaymentThrowsException);

            executionContext.Mock<OrderEffect, Order, Task<ICreateOrderResult>>(OrderEffect.Good, GoodOrderEffect);
            executionContext.Mock<OrderEffect, Order, Task<ICreateOrderResult>>(OrderEffect.Invalid, InvalidOrderEffect);
            executionContext.Mock<OrderEffect, Order, Task<ICreateOrderResult>>(OrderEffect.Exception, OrderThrowsExceptionEffect);

            base.RegisterMocks(executionContext);
        }

        private Task<ICreateOrderResult> OrderThrowsExceptionEffect(Order arg)
        {
            throw new NotImplementedException();
        }

        private Task<ICreateOrderResult> GoodOrderEffect(Order arg)
        {
            return Task.FromResult<ICreateOrderResult>(new OrderCreated(new Models.OrderAgg(arg)));
        }

        private Task<ICreateOrderResult> InvalidOrderEffect(Order arg)
        {
            return Task.FromResult<ICreateOrderResult>(new OrderNotCreated(string.Empty));
        }

        //==================================================================================================
        private Task<HttpResponseMessage> PaymentThrowsException(double totalPrice)
        {
            throw new NotImplementedException();
        }

        private Task<HttpResponseMessage> PaymentRejectedEffect(double totalPrice)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest));
        }

        private Task<HttpResponseMessage> PaymentAcceptedEffect(double totalPrice)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public override async Task Assertions(object[] path, Unit state, CreateOrderCmd op, CreateOrderResult.ICreateOrderResult result)
        {
            var cmdInput = path.OfType<CreateOrderCmdInput>().First();
            var paymentEffect = path.OfType<PaymentEffect>().First();

            var orderEffect = path.OfType<OrderEffect>().First();

            var k = (cmdInput, paymentEffect) switch
            {
                (CreateOrderCmdInput.ValidInput, PaymentEffect.Accepted) => OnValidInputAndPaymentAccepted(op, result),
                (CreateOrderCmdInput.ValidInput, PaymentEffect.Rejected) => OnValidInputAndPaymentRejected(op, result),
                (CreateOrderCmdInput.ValidInput, PaymentEffect.Exception) => OnValidInputAndExceptionThrown(op, result),
                (CreateOrderCmdInput.InvalidAmount, _) => OnInvalidInput(op, result),
                (CreateOrderCmdInput.InvalidClient, _) => OnInvalidInput(op, result),
                (CreateOrderCmdInput.InvalidRestaurant, _) => OnInvalidInput(op, result),
                _ => throw new ApplicationException("This needs to be exhaustive")
            };

            var j = (cmdInput, orderEffect) switch
            {
                (CreateOrderCmdInput.ValidInput, OrderEffect.Good) => OnValidInputAndPaymentAccepted2(op, result),
                (CreateOrderCmdInput.ValidInput, OrderEffect.Invalid) => OnValidInputAndPaymentRejected2(op, result),
                (CreateOrderCmdInput.ValidInput, OrderEffect.Exception) => OnValidInputAndExceptionThrown2(op, result),
                (CreateOrderCmdInput.InvalidAmount, _) => OnInvalidInput2(op, result),
                (CreateOrderCmdInput.InvalidClient, _) => OnInvalidInput2(op, result),
                (CreateOrderCmdInput.InvalidRestaurant, _) => OnInvalidInput2(op, result),
                _ => throw new ApplicationException("This needs to be exhaustive")
            };
        }

        private Unit OnInvalidInput2(CreateOrderCmd op, ICreateOrderResult result)
        {
            result.Match(created =>
            {
                Assert.True(false);
                return created;
            }, notcreated =>
            {
                Assert.True(false);
                return notcreated;
            }, invalidRequest =>
            {
                Assert.False(op.IsValid().Item1);
                return invalidRequest;
            });
            return Unit.Default;
        }

        private Unit OnValidInputAndExceptionThrown2(CreateOrderCmd op, ICreateOrderResult result)
        {
            result.Match(created =>
            {
                Assert.True(false);
                return created;
            }, notcreated =>
            {
                Assert.True(false);
                return notcreated;
            }, invalidRequest =>
            {
                Assert.True(op.IsValid().Item1);
                return invalidRequest;
            });
            return Unit.Default;
        }

        private Unit OnValidInputAndPaymentRejected2(CreateOrderCmd op, ICreateOrderResult result)
        {
            result.Match(created =>
            {
                Assert.True(false);
                return created;
            }, notcreated =>
            {
                Assert.True(op.IsValid().Item1);
                return notcreated;
            }, invalidRequest =>
            {
                Assert.True(false);
                return invalidRequest;
            });
            return Unit.Default;
        }

        private Unit OnValidInputAndPaymentAccepted2(CreateOrderCmd op, ICreateOrderResult result)
        {
            result.Match(created =>
            {
                Assert.True(op.IsValid().Item1);
                return created;
            }, notCreated =>
            {
                Assert.True(false);
                return notCreated;
            }, invalidRequest =>
            {
                Assert.True(false);
                return invalidRequest;
            });
            return Unit.Default;
        }

        private Unit OnValidInputAndExceptionThrown(CreateOrderCmd op, CreateOrderResult.ICreateOrderResult result)
        {
            result.Match(created =>
            {
                Assert.True(false);
                return created;
            }, notcreated =>
            {
                Assert.True(false);
                return notcreated;
            }, invalidRequest =>
            {
                Assert.True(op.IsValid().Item1);
                return invalidRequest;
            });
            return Unit.Default;
        }

        private Unit OnValidInputAndPaymentRejected(CreateOrderCmd op, CreateOrderResult.ICreateOrderResult result)
        {
            result.Match(created =>
            {
                Assert.True(false);
                return created;
            }, notcreated =>
            {
                Assert.True(op.IsValid().Item1);
                return notcreated;
            }, invalidRequest =>
            {
                Assert.True(false);
                return invalidRequest;
            });
            return Unit.Default;
        }

        private Unit OnInvalidInput(CreateOrderCmd op, CreateOrderResult.ICreateOrderResult result)
        {
            result.Match(created =>
            {
                Assert.True(false);
                return created;
            }, notcreated =>
            {
                Assert.True(false);
                return notcreated;
            }, invalidRequest =>
            {
                Assert.False(op.IsValid().Item1);
                return invalidRequest;
            });
            return Unit.Default;
        }

        private Unit OnValidInputAndPaymentAccepted(CreateOrderCmd op, CreateOrderResult.ICreateOrderResult result)
        {
            result.Match(created =>
            {
                Assert.True(op.IsValid().Item1);
                return created;
            }, notCreated =>
            {
                Assert.True(false);
                return notCreated;
            }, invalidRequest =>
            {
                Assert.True(false);
                return invalidRequest;
            });
            return Unit.Default;
        }
    }
}