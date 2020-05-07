using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using Domain.Models;
using Persistence.EfCore;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, ICreateClientResult, Unit>
    {
        //To Be Implemented
        public override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {
            try
            {
                return Task.FromResult<ICreateClientResult>(new ClientCreated(new ClientAgg(Op.Client)));
            }
            catch (Exception exp)
            {
                return Task.FromResult<ICreateClientResult>(new ClientNotCreated(exp.Message));
            }
        }
    }
}