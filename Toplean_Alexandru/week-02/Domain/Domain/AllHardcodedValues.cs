using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public class AllHardcodedValues
    {
        public static AllHardcodedValues HarcodedVals = new AllHardcodedValues();

        private AllHardcodedValues()
        {
        }

        public List<String> Restaurants { get; set; } = new List<string> { "McDonalds", "KFC", "Caruso", "Sky Restaurant" };
        public List<String> McDonaldsMenus { get; set; } = new List<string> { "McChicken", "McPuisor", "Cheeseburger", "Dublu Cheeseburger", "McFillet" };
        public List<String> KFCMenus { get; set; } = new List<string>() { "Bucket", "Zinger" };

        public List<String> Employees { get; set; } = new List<string> { "John Doe", "Jane Doe", "Zack Doe", "Alex Doe" };

        public List<Restaurant> RestaurantList { get; set; } = new List<Restaurant>
        {
            new Restaurant("McDonalds"),
            new Restaurant("KFC"),
            new Restaurant("Sky Restaurant"),
            new Restaurant("3F")
        };

        public List<String> SessionIds { get; set; } = new List<string>();

        // Dictionary SessionID => Cart
        public Dictionary<String, Cart> Carts = new Dictionary<string, Cart>() {
            { "0", new Cart() },
            { "1", new Cart() }
        };

        public List<Client> Clients { get; set; } = new List<Client> {
            //-------ClientID, ClientName, ClientUsername, ClientPassword, ClientEmail, ClientSessionID, Cart,   Table----
            new Client("0",     "Client0",     "User0",         "Pass0",      "Email0",      "0",      new Cart(),0),
            new Client("1","Client1","User1","Pass1","Email1","1", new Cart(),1),
            new Client("2","Client2","User2","Pass2","Email2","2", new Cart(),2),
            new Client("3","Client3","User3","Pass3","Email3", "3", new Cart(),3),
            new Client("4","Client4","User4","Pass4","Email4", "4", new Cart(),4),
            new Client("5","Client5","User5","Pass5","Email5", "5", new Cart(),5)
        };

        public List<MenuItem> MenuItems = new List<MenuItem>()
        {
            new MenuItem("MenuItem1",10,null,new List<string>(){"ingredient1","ingredient2" },null),
            new MenuItem("MenuItem2",10,null,new List<string>(){"ingredient3","ingredient4" },null),
            new MenuItem("MenuItem3",10,null,new List<string>(){"ingredient5","ingredient6" },null),
        };

        public List<CartItem> CartItems = new List<CartItem>()
        {
            new CartItem(new MenuItem("MenuItem1",10,null,new List<string>(){"ingredient1","ingredient2" },null),4),
            new CartItem(new MenuItem("MenuItem2",10,null,new List<string>(){"ingredient1","ingredient2" },null),5)
        };

        public Dictionary<String, List<Menu>> SpecialMenus = new Dictionary<String, List<Menu>>();
    }
}