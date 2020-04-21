using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class Storage
    {
        private static Storage instance = null;
        public static Dictionary<string,Restaurant> RestaurantCollection { get; } = new Dictionary<string, Restaurant>();
        private Storage() { }
        
        public static Storage GetInstance()
        {
            return instance == null ? new Storage() : instance;
        }

        public override string ToString()
        {
            string retVal = string.Empty;
            foreach (string name in RestaurantCollection.Keys)
                retVal += name;
            return retVal;
        }

    }
}
