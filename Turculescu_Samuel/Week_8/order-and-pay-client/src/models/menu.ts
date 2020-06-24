import { MenuItem } from "./../models/menuItem";
import { Restaurant } from "./../models/restaurant";

export type Menu = {
    id: string,
    name: string,
    restaurantId: string,
    
    menuItems: MenuItem[],
    restaurant: Restaurant
}