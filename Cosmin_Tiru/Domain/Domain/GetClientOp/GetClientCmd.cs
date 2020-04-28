using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Domain.Domain.GetClientOp
{
    public class GetClientCmd
    {
        [Required(ErrorMessage ="Null uid")]
        public string Uid { get; }
        public GetClientCmd(string uid)
        {
            Uid = uid;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }

}
