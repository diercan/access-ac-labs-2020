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
            //if (Exists(Op.ClientId))
            //{
            //    return Task.FromResult<ICreateClientResult>(new ClientNotCreated("Client already exists!"));
            //}
            //else
            //{
                ClientAgg newClient = new ClientAgg(new Client() { FirstName = Op.FirstName, LastName = Op.LastName, Email = Op.Email, Phone = Op.Phone, CardNumber = Op.CardNumber, ClientId = Op.ClientId, Password = Op.Password });
                return Task.FromResult<ICreateClientResult>(new ClientCreated(newClient));
            //}                
        }


        public bool Exists(string clientId)
        {
            if (RestaurantDomainEx.GetClient(clientId) is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
