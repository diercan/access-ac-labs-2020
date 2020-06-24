import { OrderItem } from "./../models/orderItem";
import { Restaurant } from "./../models/restaurant";

export type Order = {
    id: string,
    clientId: string,
    restaurantId: string,
    tableNumber: number,
    dateTimePlaced: Date,
    totalPrice: number,
    orderStatus: string,
    preparationTime: TimeRanges,
    paymentStatus: string
    
    // client: Client,
    restaurant: Restaurant,
    orderItems: OrderItem[]
}