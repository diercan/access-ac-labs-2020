using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Components
{
    public class Text
    {
        public String Value { get; private set; }

        public Text(String text)
        {
            Value = text;
        }
    }
}