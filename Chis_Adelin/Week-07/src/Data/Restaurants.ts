import { Restaurant } from "../Models/RestaurantModel";
import { MenuItems } from "./MenuItems";
import { DailyMenu } from "./DailyMenu";

export const restaurants: Restaurant[] = [
  {
    name: "Pizza Napoleon",
    slug: "napoleon",
    dailyMenu: DailyMenu,
  },
  {
    name: "Un restaurant oarecare",
    slug: "random",
    dailyMenu: MenuItems[0],
  },
];
