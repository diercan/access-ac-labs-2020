using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    public struct CreateMenuItemCmd
    {
        public MenuItem MenuItem { get; }

        public CreateMenuItemCmd(MenuItem menuItem)
        {
            MenuItem = menuItem;
        }

        //public int MenuID { get; }
        //public String Name { get; }
        //public double Price { get; }
        //public String Ingredients { get; }
        //public String? Alergens { get; }
        //public byte[] Image { get; }

        //public CreateMenuItemCmd(int menuId, String name, double price, String ingredients, String alergens, byte[] image)
        //{
        //    MenuID = menuId;
        //    Name = name;
        //    Price = price;
        //    Ingredients = ingredients;
        //    Alergens = alergens;
        //    Image = image;
        //}

        //public (bool, String) IsValid()
        //{
        //    return (true, "None");
        //}
    }
}