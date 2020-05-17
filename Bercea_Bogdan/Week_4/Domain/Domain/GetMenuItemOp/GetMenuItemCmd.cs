using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Domain.Domain.GetMenuItemOp
{
    public class GetMenuItemCmd
    {
        [Required(ErrorMessage = "The menuitem's name can not be NULL.")]
        public string ItemName { get; }

        [Required(ErrorMessage = "Can not search item in a NULL menu.")]
        public Menu Menu { get; }
        public GetMenuItemCmd(string name, Menu menu)
        {
            ItemName = name;
            Menu = menu;
        }
        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
