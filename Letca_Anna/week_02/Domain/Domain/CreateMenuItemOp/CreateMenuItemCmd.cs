using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Persistence.EfCore;

namespace Domain.Domain.CreateMenuItemOp
{
    
    public class CreateMenuItemCmd
    {
        [Required(ErrorMessage = "Cannot add menu item into a NULL menu.")]
        public Menus Menu { get; }

        [StringLength(100, MinimumLength = 1)]
        public string Name { get; }
        [Range(10, 100)]
        public decimal Price { get; }

        public CreateMenuItemCmd(string name, decimal price, Menus menu)
        {
            Name = name;
            Price = price;
            Menu = menu;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
