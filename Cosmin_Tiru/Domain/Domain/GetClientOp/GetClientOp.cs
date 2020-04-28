using System;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetClientOp.GetClientResult;

namespace Domain.Domain.GetClientOp
{
    public class GetClientOp : OpInterpreter<GetClientCmd, IGetClientResult, Unit>
    {
        public override Task<IGetClientResult> Work(GetClientCmd Op, Unit state)
        {
            var (valid, validationResults) = Op.Validate();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage += x.ErrorMessage);

            if (!valid)
                return Task.FromResult<IGetClientResult>(new ClientNotFound(validationMessage));
            if (!Storage.ClientCollection.ContainsKey(Op.Uid))
                return Task.FromResult<IGetClientResult>(new ClientNotFound($"Client with uid:{Op.Uid} not found!"));

            return Task.FromResult<IGetClientResult>(new ClientFound(Storage.ClientCollection[Op.Uid]));
        }
    }
}

