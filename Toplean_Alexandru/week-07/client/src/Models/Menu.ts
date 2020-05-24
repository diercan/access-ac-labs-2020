import { MenuItem } from "./MenuItem";
export type Menu = {
  id?: number;
  restaurantId?: number;
  name: string;
  menuType: string;
  specialMenu: boolean;
  hours?: string;

  menuItems?: MenuItem[];
};
