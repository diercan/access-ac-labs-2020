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
using Domain.Queries;
using Persistence;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, ICreateClientResult, Unit>
    {
        private readonly LiveInterpreterAsync interpreter;

        public async override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {
            try
            {
                return new ClientCreated(new ClientAgg(Op.Client));
            }
            catch (Exception exp)
            {
                return new ClientNotCreated(exp.Message);
            }
        }
    }
}