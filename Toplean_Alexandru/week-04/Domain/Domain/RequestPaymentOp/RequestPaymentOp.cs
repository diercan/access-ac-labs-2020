using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.RequestPaymentOp.RequestPaymentResult;

namespace Domain.Domain.RequestPaymentOp
{
    internal class RequestPaymentOp : OpInterpreter<RequestPaymentCmd, IRequestPaymentResult, Unit>
    {
        public override Task<IRequestPaymentResult> Work(RequestPaymentCmd Op, Unit state)
        {
            if (ClientExists(Op.ClientAgg))
            {
                (bool CommandIsValid, String Error) = Op.IsValid();
                if (CommandIsValid)
                {
                    // Sets the cart status to PaymentRequested to the client with the session ID = SessionID;
                    Op.ClientAgg.Cart.Payment = Cart.PaymentStatus.PaymentRequested;
                    return Task.FromResult<IRequestPaymentResult>(new PaymentRequested());
                }
                else // The session doesn't exist
                    return Task.FromResult<IRequestPaymentResult>(new PaymentNotRequested(Error));
            }
            else
                return Task.FromResult<IRequestPaymentResult>(new PaymentNotRequested("The session does not exist"));
        }

        public bool ClientExists(ClientAgg client) => client != null;
    }
}