namespace Database.Abstractions
{
    public class AddOrUpdateCmd
    {
        public object Item { get; }
        public AddOrUpdateCmd(object item)
        {
            Item = item;
        }
    }
}