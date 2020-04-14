using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.AddItemToCartOp
{
    public class AddItemToCartCmd
    {
        [Required]
        public MenuItem MenuItem;
        [Required]
        public Client Client;
        public AddItemToCartCmd(MenuItem menuItem, Client client)
        {
            MenuItem = menuItem;
            Client = client;
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
