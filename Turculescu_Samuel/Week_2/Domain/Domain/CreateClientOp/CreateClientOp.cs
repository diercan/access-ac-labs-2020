using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateClientOp.CreateClientResult;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, CreateClientResult.ICreateClientResult, Unit>
    {
        public override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {
            // Validate

            return !Exists(Op.Email) ?
                Task.FromResult<ICreateClientResult>(new ClientNotCreated("Client already exists with this email!")) :
                Task.FromResult<ICreateClientResult>(new ClientCreated(new Client(Op.FirstName, Op.LastName, Op.Email, Op.Phone, Op.CardNumber, Op.IdClient)));
        }


        public bool Exists(string email)
        {
            return true;
        }
    }
}
