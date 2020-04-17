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
            return Exists(Op.Username) ?
                Task.FromResult<ISelectClientResult>(new ClientSelected(AllHardcodedValues.HarcodedVals.Clients.FirstOrDefault(c => c.Username == Op.Username))) :
                Task.FromResult<ISelectClientResult>(new ClientNotSelected($"There is no client with the username {Op.Username}"));
        }

        public bool Exists(String name) => AllHardcodedValues.HarcodedVals.Clients.Any(c => c.Username == name);
    }
}