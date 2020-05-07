using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetClientOp.GetClientResult;

namespace Domain.Domain.GetClientOp
{
    public class GetClientOp : OpInterpreter<GetClientCmd, GetClientResult.IGetClientResult, Unit>
    {
        private List<Client>.Enumerator c = Storage.ClientsList.GetEnumerator();    // c is enumerator for ClientsList

        public override Task<IGetClientResult> Work(GetClientCmd Op, Unit state)
        {

            // Validate

            return !Exists(Op.ClientId) ?
                Task.FromResult<IGetClientResult>(new GetClientNotSuccessful($"There is no client with this id: {Op.ClientId}!")) :
                Task.FromResult<IGetClientResult>(new GetClientSuccessful(c.Current));
        }

        // Verify if restaurant selected is opened or not
        public bool Exists(string clientId)
        {
            while (c.MoveNext())
            {
                if (clientId.CompareTo(c.Current.ClientId) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}