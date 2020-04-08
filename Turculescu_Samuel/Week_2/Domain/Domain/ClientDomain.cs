using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateOrderOp;
using Domain.Models;
using Infra.Free;
using LanguageExt.ClassInstances;
using static IOExt;

namespace Domain.Domain
{
    class ClientDomain
    {
        public static IO<CreateOrderResult.ICreateOrderResult> CreateOrder(Restaurant restaurant, int idOrder, List<MenuItem> menuItems)
           => NewIO<CreateOrderCmd, CreateOrderResult.ICreateOrderResult>(new CreateOrderCmd(restaurant, idOrder, menuItems));
    }
}
