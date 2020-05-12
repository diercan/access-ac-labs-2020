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

        public CreateClientOp(LiveInterpreterAsync interpret)
        {
            interpreter = interpret;
        }

        public async override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {
            try
            {
                var query = await interpreter.Interpret(Database.Query<GetClientQuery, Client>(new GetClientQuery(Op.Client.Username)), Unit.Default);
                if (query == null)
                {
                    return new ClientCreated(new ClientAgg(Op.Client));
                }
                else
                {
                    return new ClientNotCreated("There already is a client with this Username in the database");
                }
            }
            catch (Exception exp)
            {
                return new ClientNotCreated(exp.Message);
            }
        }
    }
}