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
            if (!Exists(Op.Username))
            {
                (bool CommandIsValid, String Error) = Op.IsValid();
                if (CommandIsValid)
                {
                    try
                    {
                        Client client = new Client(Op.Name, Op.Username, Op.Password, Op.Email, null);
                        return Task.FromResult<ICreateClientResult>(new ClientCreated(new ClientAgg(client)));
                    }
                    catch (Exception exp)
                    {
                        return Task.FromResult<ICreateClientResult>(new ClientNotCreated(exp.Message));
                    }
                }
                else
                    return Task.FromResult<ICreateClientResult>(new ClientNotCreated(Error));
            }
            else
            {
                return Task.FromResult<ICreateClientResult>(new ClientNotCreated("The username already exists in the database"));
            }
        }

        public bool Exists(String Username) => false;
    }
}