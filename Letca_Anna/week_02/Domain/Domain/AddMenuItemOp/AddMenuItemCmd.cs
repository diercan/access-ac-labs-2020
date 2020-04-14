using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.AddMenuItemOp
{
    public class AddMenuItemCmd
    {
        [Required]
        public Menu Menu { get; }
        [Required]
        public MenuItem MenuItem { get; }

        public AddMenuItemCmd(MenuItem menuItem, Menu menu)
        {
            MenuItem = menuItem;
            Menu = menu;
        }

        public (bool, string) Validate()
        {
            var validationResults = new List<ValidationResult>();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage.Append(x.ErrorMessage));
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationMessage);
        }
    }
}
