using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientCmd
    {
        [Required]
        public string Uid { get; }

        public CreateClientCmd(string uid)
        {
            Uid = uid;
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
