using OrderAndPay.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAndPay.Web.Commands;

namespace OrderAndPay.Web
{
    public static class InMemoryRepository
    {
        private static List<Menu> _menus;
        private static List<MenuItem> _menuItems;
        static InMemoryRepository()
        {
            _menus = new List<Menu>{
                new Menu {
                    Id = 1,
                    Name = "Main Course",
                    MenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Id = 1,
                            Name = "Artichoke and Spinach Dip",
                            Price = 50
                        },
                        new MenuItem
                        {
                            Id = 2,
                            Name = "Fried Calamari",
                            Price = 45
                        },
                        new MenuItem
                        {
                            Id = 3,
                            Name = "Shrimp Scampi",
                            Price = 55
                        },
                        new MenuItem
                        {
                            Id = 4,
                            Name = "Stuffed Mushrooms",
                            Price = 45
                        }, new MenuItem
                        {
                            Id = 5,
                            Name = "Four Cheese Garlic Bread",
                            Price = 25
                        }
                    }
                },
                new Menu
                {
                    Id = 2,
                    Name = "Drinks Menu",
                    MenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Id = 1,
                            Name = "Espresso",
                            Price = 5
                        },
                        new MenuItem
                        {
                            Id = 2,
                            Name = "Cappuccino",
                            Price = 10
                        },
                        new MenuItem
                        {
                            Id = 3,
                            Name = "Latte Macchiato",
                            Price = 8
                        },
                        new MenuItem
                        {
                            Id = 4,
                            Name = "Coca Cola",
                            Price = 8
                        },
                        new MenuItem
                        {
                            Id = 5,
                            Name = "Fanta - Lemon",
                            Price = 5
                        }
                    }
                },
                new Menu
                {
                    Id = 3,
                    Name = "Dessert Menu",
                    MenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Id = 1,
                            Name = "Tiramisu Budino",
                            Price = 35
                        },
                        new MenuItem
                        {
                            Id = 2,
                            Name = "Pine Nut Tart",
                            Price = 34
                        },
                        new MenuItem
                        {
                            Id = 3,
                            Name = "Ricotta Zeppole",
                            Price = 40
                        },
                        new MenuItem
                        {
                            Id = 4,
                            Name = "Strawberry Panna Cotta",
                            Price = 35
                        }
                    }

                }
            };
        }
        public static List<MenuDto> GetMenus(int restaurantId)
        {
            return _menus.Select(m => new MenuDto { Id = m.Id, Name = m.Name }).ToList();
        }

        public static Menu GetMenuDetails(int restaurantId, int menuId)
        {
            return _menus.FirstOrDefault(m => m.Id == menuId);
        }

        public static MenuItem CreateMenuItem(int restaurantId, int menuId, CreateMenuItemCommand cmd)
        {
            var menu = _menus.First(m => m.Id == menuId);
            var item = new MenuItem
            {
                Name = cmd.Name,
                Price = cmd.Price,
                Id = menu.MenuItems.Count + 1
            };
            menu.MenuItems.Add(item);
            return item;
        }
    }
}
