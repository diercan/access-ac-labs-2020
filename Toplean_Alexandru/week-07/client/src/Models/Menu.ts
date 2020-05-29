import { MenuItem } from "./MenuItem";
export type Menu = {
  Id: number;
  RestaurantId?: number;
  Name: string;
  MenuType: string;
  Visibility: boolean;
  Hours?: string;

  MenuItem: MenuItem[];
};
