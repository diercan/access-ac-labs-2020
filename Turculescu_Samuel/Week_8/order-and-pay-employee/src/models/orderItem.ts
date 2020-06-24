import { MenuItem } from "./menuItem";
import { Order } from "./order";

export type OrderItem = {
    id: string,
    name: string,
    menuItemId: string,
    orderId: string,
    quantity: number,
    specialRequests: number,
    price: number    
    
    menuItem: MenuItem,
    order: Order
}