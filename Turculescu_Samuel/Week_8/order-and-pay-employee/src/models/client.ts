import { Order } from "./order";

export type Client = {
    id: string,
    firstName: string,
    lastName: string,
    email: string,
    phone: string,
    cardNumber: string,
    clientId: string,
    password: string,

    placedOrders: Order[]
}