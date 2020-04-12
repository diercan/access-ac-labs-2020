using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.CreateMenuItemOp
{
    
    public class CreateMenuItemCmd
    {
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; }
        [Range(10, 100)]
        public double Price { get; }

        public CreateMenuItemCmd(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
