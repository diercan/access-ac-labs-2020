using Domain.Domain.CustomValidationAttributes;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Domain.GetAllRestaurantsOp
{
    public class GetAllRestaurantsCmd
    {
        [Required(ErrorMessage = "ValidationError_GetAllRestaurants: Null restaurants list.")]
        [ListNotEmpty(ErrorMessage = "ValidationError_GetAllRestaurant: Empty restaurants list.")]
        public List<Restaurant> Restaurants { get; }

        public GetAllRestaurantsCmd(List<Restaurant> restaurants)
        {
            Restaurants = restaurants;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
