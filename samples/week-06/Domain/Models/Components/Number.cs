using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Components
{
    public class Number
    {
        public double Value { get; private set; }

        public Number(double value)
        {
            Value = value;
        }
    }
}