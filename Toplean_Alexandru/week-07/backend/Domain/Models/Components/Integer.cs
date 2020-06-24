using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Components
{
    public class Integer
    {
        public int Value { get; private set; }

        public Integer(int value)
        {
            Value = value;
        }
    }
}