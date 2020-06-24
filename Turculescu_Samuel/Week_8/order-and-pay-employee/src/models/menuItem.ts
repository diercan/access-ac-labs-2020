import { Menu } from "./menu";
import { OrderItem } from "./orderItem";

export type MenuItem = {
    id?: string,
    name: string,
    ingredients: string,
    allergens: string,
    totalQuantity: number,
    price: number,
    availability: number,
    menuId: number,

    //menu: Menu,
    //orderItems: OrderItem[]

}