using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Persistence.EfCore;

namespace Domain.Domain.CreateMenuItemOp
{
    
    public class CreateMenuItemCmd
    {
        [Range(10, 100)]
        public decimal Price { get; }

        [StringLength(100, MinimumLength = 1)]
        public string Name { get; }

        public MenuItems MenuItem { get; }

        [Required(ErrorMessage = "ValidationError_CreateMenuItem:Cannot create item for a NULL menu.")]
        public int? MenuId { get; }

        public CreateMenuItemCmd(MenuItems menuItem, int? menuId)
        {
            Name = menuItem.Name;
            Price = menuItem.Price;
            MenuId = menuId;
            MenuItem = menuItem;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
