using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.CreateRestauratOp
{
    public class CreateRestaurantCmd
    {
        [StringLength(100,MinimumLength = 1)]
        public string Name { get; }

        public CreateRestaurantCmd(string name)
        {
            Name = name;
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
