import { axiosClient } from "./axiosClient";
import { handleError } from "./apiUtils";

export const getMenus = () => {
  return axiosClient.get("employee/restaurants/1/menus").catch(handleError);
};

export const getMenu = (menuId: string) => {
  return axiosClient
    .get(`employee/restaurants/1/menus/${menuId}`)
    .catch(handleError);
};
