using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateClientOp.CreateClientResult;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, ICreateClientResult, Unit>
    {
        public override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {
            var client = new Client(Op.Name);
            Op.Clients.Add(client);
            return Task.FromResult((ICreateClientResult)new ClientCreated(client));
        }
    }
}
