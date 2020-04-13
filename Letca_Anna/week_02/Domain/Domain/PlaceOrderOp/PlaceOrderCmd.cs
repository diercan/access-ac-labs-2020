using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.PlaceOrderOp
{
    public class PlaceOrderCmd
    {
        [Required]
        public Order Order { get; }
        [Required]
        public Restaurant Restaurant { get; }

        public PlaceOrderCmd(Order order, Restaurant restaurant)
        {
            Order = order;
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
