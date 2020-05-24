import { Menu, MenuDetails } from "./menu";
export const menus: Menu[] = [
  { id: "1", name: "Main Course" },
  { id: "2", name: "Drinks Menu" },
  { id: "3", name: "Dessert Menu" },
];

export const menu: { [id: string]: MenuDetails } = {
  "1": {
    name: "Main Course",
    id: "1",
    menuItems: [
      { id: "1", name: "Artichoke and Spinach Dip", price: 50 },
      { id: "2", name: "Fried Calamari", price: 45 },
      { id: "3", name: "Shrimp Scampi", price: 55 },
      { id: "4", name: "Stuffed Mushrooms", price: 45 },
      { id: "5", name: "Four Cheese Garlic Bread", price: 25 },
    ],
  },
  "2": {
    name: "Drinks Menu",
    id: "2",
    menuItems: [
      { id: "1", name: "Espresso", price: 5 },
      { id: "2", name: "Cappuccino", price: 10 },
      { id: "3", name: "Latte Macchiato", price: 8 },
      { id: "4", name: "Coca Cola", price: 8 },
      { id: "5", name: "Fanta - Lemon", price: 8 },
    ],
  },
  "3": {
    name: "Dessert Menu",
    id: "2",
    menuItems: [
      { id: "1", name: "Tiramisu Budino", price: 35 },
      { id: "2", name: "Pine Nut Tart", price: 34 },
      { id: "3", name: "Ricotta Zeppole", price: 40 },
      { id: "4", name: "Strawberry Panna Cotta", price: 45 },
    ],
  },
};
