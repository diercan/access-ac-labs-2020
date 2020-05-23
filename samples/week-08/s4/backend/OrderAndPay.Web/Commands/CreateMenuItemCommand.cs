using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndPay.Web.Commands
{
    public class CreateMenuItemCommand
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
