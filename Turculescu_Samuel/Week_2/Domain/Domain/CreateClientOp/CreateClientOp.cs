using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateClientOp.CreateClientResult;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, CreateClientResult.ICreateClientResult, Unit>
    {
        public override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {
            Client newClient = new Client(Op.FirstName, Op.LastName, Op.Email, Op.Phone, Op.CardNumber, Op.ClientId);

            // Validate
            return !Exists(newClient) ?
                Task.FromResult<ICreateClientResult>(new ClientNotCreated("Client already exists!")) :
                Task.FromResult<ICreateClientResult>(new ClientCreated(newClient));
        }


        public bool Exists(Client client)
        {
            if(Storage.ClientsList.Contains(client))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
