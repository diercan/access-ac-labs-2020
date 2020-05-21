import { Employee } from "./Employee";
import { Menu } from "./Menu";
import { Order } from "./Order";

export type Restaurant = {
  id?: number;
  name?: string;
  stars: number;
  imageURL?: string;

  menus: Menu[];
  employees?: Employee[];
  orders?: Order[];
};
