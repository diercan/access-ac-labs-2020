using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Domain.Domain.GetMenuOp
{
    public class GetMenuCmd
    {
        [Required]
        public Restaurant Restaurant { get; }

        public GetMenuCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
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
