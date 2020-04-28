using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.PlaceOrderOp
{
    public class PlaceOrderCmd
    {
        [Required(ErrorMessage = "Cannot place a NULL order.")]
        public Order Order { get; }
        [Required(ErrorMessage = "Cannot place orders to a NULL restaurant.")]
        public RestaurantAgg Restaurant { get; }

        public PlaceOrderCmd(Order order, RestaurantAgg restaurant)
        {
            Order = order;
            Restaurant = restaurant;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
