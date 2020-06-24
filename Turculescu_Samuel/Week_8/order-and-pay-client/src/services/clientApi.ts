import { axiosClient } from "./axiosClient";
import { handleError } from "./apiUtils";

  export const getClient = (clientId: string) => {
    return axiosClient
      .get(`${clientId}`)
      .catch(handleError);
  };

  export const getRestaurants = () => {
    return axiosClient
      .get(`first.client/restaurants`)
      .catch(handleError);
  };

  export const getRestaurant = (restaurantName: string) => {
    return axiosClient
      .get(`first.client/restaurant/${restaurantName}`)
      .catch(handleError);
  };  
  
  export const getMenus = () => {
      return axiosClient
        .get(`first.client/restaurant/Piata 9/menus`)
        .catch(handleError);
    };

    export const getMenuItems = (menuId: string) => {
      return axiosClient
        .get(`first.client/restaurant/Piata 9/menus/${menuId}`)
        .catch(handleError);
    };

    export const getOrders = () => {
    return axiosClient
      .get(`first.client/orders`)
      .catch(handleError);
  };

  export const getOrderItems = (orderId: string) => {
    return axiosClient
      .get(`first.client/orders/${orderId}`)
      .catch(handleError);
  };

  // export const getClient = (clientId: string) => {
  //   return axiosClient
  //     .get(`client/${clientId}`)
  //     .catch(handleError);
  // };

  // export const getRestaurants = () => {
  //   return axiosClient
  //     .get(`client/first.client/restaurants`)
  //     .catch(handleError);
  // };

  // export const getRestaurant = (clientId: string, restaurantName: string) => {
  //   return axiosClient
  //     .get(`client/${clientId}/restaurants/${restaurantName}`)
  //     .catch(handleError);
  // };  

  // export const getMenus = (clientId: string, restaurantName: string) => {
  //   return axiosClient
  //     .get(`client/${clientId}/restaurants/${restaurantName}/menus`)
  //     .catch(handleError);
  // };
  
  // export const getMenuItems = (clientId: string, restaurantName: string, menuId: string) => {
  //   return axiosClient
  //     .get(`client/${clientId}/restaurants/${restaurantName}/menus/${menuId}`)
  //     .catch(handleError);
  // };

  // export const getOrders = (clientId: string) => {
  //   return axiosClient
  //     .get(`client/${clientId}/orders`)
  //     .catch(handleError);
  // };

  // export const getOrderItemss = (clientId: string, orderId: string) => {
  //   return axiosClient
  //     .get(`client/${clientId}/orders/${orderId}`)
  //     .catch(handleError);
  // };