using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.HardcodedValues
{
    public static class MenuItemValues
    {
        public static List<string> getIngredients() => new List<string> { "Faina", "Ou", "Piper", "Sare", "Branza", "Sos de rosii" };
        public static List<string> getAlergens() => new List<string> { "Ou", "Piper" };
        public static Menu getMenu() => new Menu("Italian Menu", MenuType.Meat);
    }
}
