using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateOrderOp;
using Domain.Domain.CreateClientOp;
using Domain.Models;
using Infra.Free;
using LanguageExt.ClassInstances;
using static IOExt;
using static Domain.Domain.CreateClientOp.CreateClientResult;

namespace Domain.Domain
{
    class ClientDomain
    {
        public static IO<ICreateClientResult> CreateClient(string name) =>
            NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(name));

        public static IO<CreateOrderResult.ICreateOrderResult> CreateOrder(Client client, Restaurant restaurant, int idOrder, List<MenuItem> menuItems)
           => NewIO<CreateOrderCmd, CreateOrderResult.ICreateOrderResult>(new CreateOrderCmd(client, restaurant, idOrder, menuItems));
    }
}
