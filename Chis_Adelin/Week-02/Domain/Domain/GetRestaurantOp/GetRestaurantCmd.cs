namespace Domain.Domain.GetRestaurantOp
{
    public struct GetRestaurantCmd
    {
        public string Name { get; }

        public GetRestaurantCmd(string name)
        {
            Name = name;
        }
    }
}