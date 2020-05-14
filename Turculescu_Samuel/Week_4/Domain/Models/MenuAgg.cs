using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MenuAgg
    {
        public Menu Menu { get; set; }

        public MenuAgg(Menu menu)
        {
            Menu = menu;
        }
    }
}
