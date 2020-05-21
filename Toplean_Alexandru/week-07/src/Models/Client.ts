import { Order } from "./Order";
export type Client = {
  id?: number;
  name: string;
  username: string;
  password: string;
  email: string;
  tableNumber?: number;
  sessionId?: number;
  orders: Order[];
};
