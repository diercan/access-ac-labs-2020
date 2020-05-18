using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Persistence.EfCore
{
    public partial class MenuItem : IEntity
    {
        public MenuItem()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public MenuItem(int menuId, String name, String ingredients, String alergens, double price, byte[] image)
        {
            MenuId = menuId;
            Name = name;
            Ingredients = ingredients;
            Alergens = alergens;
            Price = price;
            Image = image;
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public int MenuId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public string Alergens { get; set; }

        [Required]
        public double Price { get; set; }

        public byte[] Image { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Menu Menu { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}