using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EarlyPay.Primitives.Mocking;
using LanguageExt;
using Xunit;

namespace Domain.Domain.CreateOrderOp
{
    public partial class CreateOrderOp
    {
        public override void RegisterMocks(IMockableContext executionContext)
        {
            executionContext.Mock<PaymentEffect, double, Task<HttpResponseMessage>>(PaymentEffect.Accepted, PaymentAcceptedEffect);
            executionContext.Mock<PaymentEffect, double, Task<HttpResponseMessage>>(PaymentEffect.Rejected, PaymentRejectedEffect);
            executionContext.Mock<PaymentEffect, double, Task<HttpResponseMessage>>(PaymentEffect.Exception, PaymentThrowsException);

            base.RegisterMocks(executionContext);
        }

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

            var _ = (cmdInput, paymentEffect) switch
            {
                (CreateOrderCmdInput.ValidInput, PaymentEffect.Accepted) => OnValidInputAndPaymentAccepted(op, result),
                (CreateOrderCmdInput.InvalidAmount, _) => OnInvalidInput(op, result),
                (CreateOrderCmdInput.InvalidClient, _) => OnInvalidInput(op, result),
                _ => throw new ApplicationException("This needs to be exhaustive")
            };
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
