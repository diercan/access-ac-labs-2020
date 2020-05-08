using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Domain.Entities;

namespace Persistence.EfCore
{
    public partial class MenuItem : IEntity
    {
        public MenuItem()
        {
        }

        public MenuItem(int menuId, String name, String ingredients, String alergens, double price, byte[] image)
        {
            MenuId = menuId;
            Name = name;
            Ingredients = ingredients;
            Alergens = alergens;
            Price = price;
            Image = image;
        }

        public int Id { get; set; }

        [Required]
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
    }
}