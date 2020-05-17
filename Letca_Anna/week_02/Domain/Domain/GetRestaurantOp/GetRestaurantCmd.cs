using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantCmd
    {
        [Required(ErrorMessage = "ValidationError_GetRestaurant: Null restaurant.")]
        public Restaurant Restaurant { get; }

        public GetRestaurantCmd(Restaurant restaurant)
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
