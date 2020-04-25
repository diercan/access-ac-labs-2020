using Domain.Models;

namespace Domain.Domain.GetClientOp
{
    public struct GetClientCmd
    {
        public string Name { get; }
        public Cart Cart { get; }

        public GetClientCmd(string name, Cart cart)
        {
            Name = name;
            Cart = cart;
        }
    }
}