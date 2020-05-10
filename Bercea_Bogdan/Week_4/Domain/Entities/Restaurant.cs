using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.EfCore
{
    public partial class Restaurant
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Restauran must have name")]
        [MaxLength(200, ErrorMessage = "Restauran name must be up to 200 characters")]
        public string Name { get; set; }

        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
    }
}
