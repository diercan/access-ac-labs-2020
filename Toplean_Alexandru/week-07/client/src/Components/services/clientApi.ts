import { Restaurant } from "./../../Models/Restaurant";
import { axiosClient } from "./axiosClient";
import { handleError } from "./apiUtils";
import { Order } from "../../Models/Order";
import { OrderItem } from "../../Models/OrderItem";

/* export const getMenus = () => {
  return axiosClient.get("employee/restaurants/1/menus").catch(handleError);
}; */

export const getRestaurants = () => {
  return axiosClient.get(`client/restaurant/All`).catch(handleError);
};

export const getRestaurant = (restaurant: string) => {
  return axiosClient.get(`client/restaurant/${restaurant}`);
};

export const getMenus = (restaurant: string) => {
  return axiosClient.get(`client/restaurant/${restaurant}/allmenus`);
};

export const getMenuItems = (restaurant: string, menu: string) => {
  return axiosClient.get(
    `client/restaurant/${restaurant}/${menu}/allmenuitems`
  );
};

export const getMenuItemById = (id: number) => {
  return axiosClient.get(`client/getmenuitembyid/${id}`);
};

export const getClient = (username: string, password: string) => {
  return axiosClient.get(`client/login/${username}/${password}`);
};

export const getMenuItemsById = (ids: string) => {
  return axiosClient.get(`/client/GetAllMenuItemsByListId/${ids}`);
};

export const createOrder = (order: Order) => {
  return axiosClient.post(`client/Createorder`, order);
};

export const createOrderItem = (orderItem: OrderItem) => {
  return axiosClient.post(`client/CreateOrderItem`, orderItem);
};

export const createClient = (
  name: string,
  username: string,
  password: string,
  email: string
) => {
  return axiosClient.post(`client/createclient`, {
    Name: name,
    Username: username,
    Password: password,
    Email: email,
  });
};

/* export const getMenu = (menuId: string) => {
  return axiosClient
    .get(`employee/restaurants/1/menus/${menuId}`)
    .catch(handleError);
};

export const createMenuItem = (menuId: string, item: MenuItem) => {
  return axiosClient
    .post(`employee/restaurants/1/menus/${menuId}/items`, {
      name: item.name,
      price: item.price,
    })
    .catch(handleError);
}; */
