using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Domain.Domain.GetMenuOp
{
    public class GetMenuCmd
    {
        [Required(ErrorMessage = "Null restaurant. Select a restaurant first.")]
        public RestaurantAgg Restaurant { get; }

        public GetMenuCmd(RestaurantAgg restaurant)
        {
            Restaurant = restaurant;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
