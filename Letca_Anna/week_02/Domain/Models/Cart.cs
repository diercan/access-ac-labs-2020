using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Cart
    {
        public List<MenuItem> MenuItems { get; } = new List<MenuItem>();

    }
}
