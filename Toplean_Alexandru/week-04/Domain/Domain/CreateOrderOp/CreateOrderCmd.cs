using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infra.Free;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    public struct CreateOrderCmd
    {
        public Order Order { get; }

        public CreateOrderCmd(Order order)
        {
            Order = order;
        }

        public (bool, String) IsValid()
        {
            if (Order.TotalPrice < 0)
                return (false, "Price cannot be negative");
            if (Order.ClientId < 0)
                return (false, "No client");
            if (Order.RestaurantId < 0)
                return (false, "No restaurant");
            return (true, "None");
        }

        public bool IncorectInputType(dynamic value, Type expectedType) => value.GetType() != expectedType ? true : false;  // Checks if a variable is the correct type
    }

    public class CreateOrderCmdInputGen : InputGenerator<CreateOrderCmd, CreateOrderCmdInput>
    {
        public CreateOrderCmdInputGen()
        {
            mappings.Add(CreateOrderCmdInput.ValidInput, () => new CreateOrderCmd(new Order(1, 1, 1, 10, "CREATED", "ACCEPTED")));
            mappings.Add(CreateOrderCmdInput.InvalidClient, () => new CreateOrderCmd(new Order(-1, 1, 1, 10, "CREATED", "ACCEPTED")));
            mappings.Add(CreateOrderCmdInput.InvalidAmount, () => new CreateOrderCmd(new Order(0, 1, 1, -10, "CREATED", "ACCEPTED")));
            mappings.Add(CreateOrderCmdInput.InvalidRestaurant, () => new CreateOrderCmd(new Order(0, -1, 1, -10, "CREATED", "ACCEPTED")));
        }
    }

    public enum CreateOrderCmdInput
    {
        ValidInput,
        InvalidClient,
        InvalidAmount,
        InvalidRestaurant
    }
}