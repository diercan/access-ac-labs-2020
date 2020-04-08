using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class AllHardcodedValues
    {
        public static AllHardcodedValues HarcodedVals = new AllHardcodedValues();

        private AllHardcodedValues()
        {
        }

        public List<String> Restaurants { get; set; } = new List<string> { "McDonalds", "KFC", "Caruso", "Sky Restaurant" };
        public List<String> McDonaldsMenus { get; set; } = new List<string> { "McChicken", "McPuisor", "Cheeseburger", "Dublu Cheeseburger", "McFillet" };
        public List<String> KFCMenus { get; set; } = new List<string>() { "Bucket", "Zinger" };

        public List<String> Employees { get; set; } = new List<string> { "John Doe", "Jane Doe", "Zack Doe", "Alex Doe" };
    }
}