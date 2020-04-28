using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using LanguageExt.ClassInstances.Pred;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, ICreateClientResult, Unit>
    {
        public override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {

            var (valid, validationResults) = Op.Validate();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage += x.ErrorMessage);

            if (!valid)
                return Task.FromResult((ICreateClientResult)new ClientNotCreated(validationMessage));

            if(Storage.ClientCollection.ContainsKey(Op.Uid))
                return Task.FromResult((ICreateClientResult)new ClientNotCreated($"Client with uid {Op.Uid} already exists!"));

            Client newClient = new Client(Op.Uid, Op.Name);
            Storage.ClientCollection[Op.Uid] = newClient;
            return Task.FromResult((ICreateClientResult)new ClientCreated(newClient));
        }
    }
}
