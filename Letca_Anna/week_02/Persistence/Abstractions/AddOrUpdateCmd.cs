using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.Abstractions
{
    public class AddOrUpdateCmd
    {
        [Required(ErrorMessage = "Cannot add or update a NULL item.")]
        public object Item { get; }
        public AddOrUpdateCmd(object item)
        {
            Item = item;
        }

        public (bool, List<ValidationResult>) Validate()
        {
            var validationResults = new List<ValidationResult>();
            return (Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true), validationResults);
        }
    }
}
