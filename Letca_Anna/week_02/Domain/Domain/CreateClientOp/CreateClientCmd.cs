using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Domain.Domain.CreateClientOp
{
    public class CreateClientCmd
    {
        [Required(ErrorMessage = "Cannot create client with NULL uid.")]
        public string Uid { get; }
        public string Name { get; }

        public CreateClientCmd(string uid, string name)
        {
            Uid = uid;
            Name = name;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
