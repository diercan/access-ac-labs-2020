using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.CreateClientOp.CreateClientResult;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, CreateClientResult.ICreateClientResult, Unit>
    {
        public override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {
            ClientAgg newClient = new ClientAgg(new Client() { Id = Op.ClientId, FirstName = Op.FirstName, LastName = Op.LastName, Email = Op.Email, Phone = Op.Phone, CardNumber = Op.CardNumber });

            // Validate
            return !Exists(newClient) ?
                Task.FromResult<ICreateClientResult>(new ClientNotCreated("Client already exists!")) :
                Task.FromResult<ICreateClientResult>(new ClientCreated(newClient));
        }


        public bool Exists(ClientAgg client)
        {
            if(App.ClientsList.Contains(client.Client))
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
