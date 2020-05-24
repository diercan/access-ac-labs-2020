import { OrderItem } from "./OrderItem";
export type Order = {
  id?: number;
  clientId?: number;
  restaurantId?: number;
  tableNumber: number;
  totalProce: number;
  status: string;
  paymentStatus: string;

  orderItems: OrderItem[];
};
