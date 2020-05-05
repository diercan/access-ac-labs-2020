using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Domain.CustomValidationAttributes
{
    class ListNotEmpty : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            return list.Count > 0;
        }
    }
}
