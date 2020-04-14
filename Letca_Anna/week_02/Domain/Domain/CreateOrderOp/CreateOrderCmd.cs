using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Domain.Domain.CreateOrderOp
{
    public class CreateOrderCmd
    {
        [Required]
        public Client Client { get; }

        public CreateOrderCmd(Client client)
        {
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
