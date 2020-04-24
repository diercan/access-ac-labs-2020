using CSharp.Choices.Attributes;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using static Domain.Domain.SelectClientOp.SelectClientResult;

namespace Domain.Domain.SelectClientOp
{
    public class SelectClientOp : OpInterpreter<SelectClientCmd, ISelectClientResult, Unit>
    {
        public override Task<ISelectClientResult> Work(SelectClientCmd Op, Unit state)
        {
            return Exists(Op.SessionID) ?
                Task.FromResult<ISelectClientResult>(new ClientSelected(AllHardcodedValues.HarcodedVals.Clients.FirstOrDefault(c => c.SessionID == Op.SessionID))) :
                Task.FromResult<ISelectClientResult>(new ClientNotSelected($"There is no client with the Session ID {Op.SessionID}"));
        }

        public bool Exists(String sessionId) => AllHardcodedValues.HarcodedVals.Clients.Any(c => c.SessionID == sessionId);
    }
}