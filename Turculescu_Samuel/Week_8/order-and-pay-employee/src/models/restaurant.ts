import { Menu } from "./../models/menu";
import { Order } from "./../models/order";

export type Restaurant = {
    id: string,
    name: string,
    address: string
    
    // employees: Employee[],
     menus: Menu[],
     order: Order[]
}