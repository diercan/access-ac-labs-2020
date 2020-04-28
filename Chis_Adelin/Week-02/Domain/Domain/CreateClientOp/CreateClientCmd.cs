namespace Domain.Domain.CreateClientOp
{
    public struct CreateClientCmd
    {
        public string Name { get; }

        public CreateClientCmd(string name)
        {
            Name = name;
        }
    }
}