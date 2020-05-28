using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Persistence.EfCore
{
    public partial class Menu : IEntity
    {
        public Menu()
        {
            MenuItem = new HashSet<MenuItem>();
            OrderItems = new HashSet<OrderItems>();
        }

        public Menu(int restaurantID, String name, String menuType, bool isVisible, string hours)
        {
            RestaurantId = restaurantID;
            Name = name;
            MenuType = menuType;
            Visibility = isVisible;
            Hours = hours;
            MenuItem = new HashSet<MenuItem>();
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string MenuType { get; set; }

        public bool Visibility { get; set; }
        public string Hours { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<MenuItem> MenuItem { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}