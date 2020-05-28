using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.EfCore
{
    public partial class Restaurant : IEntity
    {
        public Restaurant()
        {
            Employee = new HashSet<Employee>();
            Menu = new HashSet<Menu>();
            Order = new HashSet<Order>();
        }

        public Restaurant(String name, string image = null, int stars = 0)
        {
            Name = name;
            Image = image;
            Stars = stars;

            Employee = new HashSet<Employee>();
            Menu = new HashSet<Menu>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Image { get; set; }
        public int? Stars { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}