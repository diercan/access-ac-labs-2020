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
        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
