import { axiosClient } from "./axiosClient";
import { handleError } from "./apiUtils";

export const getRestaurant = () => {
    return axiosClient.get(`Client/restaurant/test`).catch(handleError);
};

export const getAllRestaurants = () => {
    return axiosClient.get(`Client/restaurants`).catch(handleError);
};

