using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using Domain.Models;

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
                    Client dummy = new Client(null, null, null, null, null, null, null, 0);
                    Client client = new Client(null, Op.Name, Op.Username, Op.Password, Op.Email, dummy.GenerateSessionID(), new Cart());

                    AllHardcodedValues.HarcodedVals.Clients.Add(client);
                    return Task.FromResult<ICreateClientResult>(new ClientCreated(client));
                }
                else
                    return Task.FromResult<ICreateClientResult>(new ClientNotCreated(Error));
            }
            else
            {
                return Task.FromResult<ICreateClientResult>(new ClientNotCreated("The username already exists in the database"));
            }
        }

        public bool Exists(String Username) => AllHardcodedValues.HarcodedVals.Clients.Any(c => c.Username == Username);
    }
}