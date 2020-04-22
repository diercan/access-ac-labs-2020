using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Domain.Domain.CreateOrderOp
{
    public class CreateOrderCmd
    {
        [Required(ErrorMessage = "Cannot create the order of a NULL initiator.")]
        public Client Client { get; }

        public CreateOrderCmd(Client client)
        {
            Client = client;
        }
        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
