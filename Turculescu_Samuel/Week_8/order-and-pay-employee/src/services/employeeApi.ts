import { axiosEmployee } from "./axiosEmployee";
import { handleError } from "./apiUtils";
import { MenuItem } from "../models/menuItem";

  export const getEmployee = (employeeId: string) => {
    return axiosEmployee
      .get(`${employeeId}`)
      .catch(handleError);
  };

  export const getRestaurant = (restaurantName: string) => {
    return axiosEmployee
      .get(`waiter01/restaurant/${restaurantName}`)
      .catch(handleError);
  };  
  
  export const getMenus = () => {
      return axiosEmployee
        .get(`waiter01/restaurant/Restaurant_1/menus`)
        .catch(handleError);
    };

    export const getMenuItems = (menuId: string) => {
      return axiosEmployee
        .get(`waiter01/restaurant/Restaurant_1/menus/${menuId}`)
        .catch(handleError);
    };

    export const getOrders = () => {
    return axiosEmployee
      .get(`waiter01/restaurant/Restaurant_1/orders`)
      .catch(handleError);
  };

  export const getOrderItems = (orderId: string) => {
    return axiosEmployee
      .get(`waiter01/restaurant/Restaurant_1/orders/${orderId}`)
      .catch(handleError);
  };

  export const createMenuItem = (menuId: string, item: MenuItem) => {
    return axiosEmployee
      .post(`employee/restaurants/Restaurant_1/menus/${menuId}/items`, {
        name: item.name,
        ingredients: item.ingredients,
        allergens: item.allergens,
        totalQuantity: item.totalQuantity,
        price: item.price,
        availability: item.availability,
        menuId: menuId
      })
      .catch(handleError);
  };

  