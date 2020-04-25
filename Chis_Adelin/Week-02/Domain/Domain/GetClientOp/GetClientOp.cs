using System.Threading.Tasks;
using LanguageExt;
using System;
using System.Data.SqlTypes;
using Infrastructure.Free;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetClientOp.GetClientResult;

namespace Domain.Domain.GetClientOp
{
    public class GetRestaurantOp : OpInterpreter<GetClientCmd, IGetClientResult,Unit>
    {
        public override Task<IGetClientResult> Work(GetClientCmd Op, Unit state)
        {
            if (Exists(Op.Name))
                return Task.FromResult<IGetClientResult>(new ClientFound(Op.Name));
            else
                return Task.FromResult<IGetClientResult>(new ClientNotFound("nu-i aci"));
        }
        public bool Exists(string name)
        {
            return true;
        }
    }
}