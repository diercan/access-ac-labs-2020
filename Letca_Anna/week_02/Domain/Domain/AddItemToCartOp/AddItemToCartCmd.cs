using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.AddItemToCartOp
{
    public class AddItemToCartCmd
    {
        [Required(ErrorMessage = "Cannot add NULL item into cart.")]
        public MenuItem MenuItem;
        [Required(ErrorMessage = "Cannot add items into the cart of a NULL client.")]
        public Client Client;
        public AddItemToCartCmd(MenuItem menuItem, Client client)
        {
            MenuItem = menuItem;
            Client = client;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
