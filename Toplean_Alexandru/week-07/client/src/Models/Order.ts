import { OrderItem } from "./OrderItem";
export type Order = {
  id?: number;
  clientId?: number;
  restaurantId?: number;
  tableNumber: number;
  totalPrice: number;
  status: string;
  paymentStatus: string;

  orderItems: OrderItem[];
};
