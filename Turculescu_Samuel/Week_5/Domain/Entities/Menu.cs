using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Persistence.EfCore
{
    public partial class Menu
    {
        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Restaurant Restaurant { get; set; }

        public virtual List<MenuItem> MenuItems { get; set; }
    }
}

