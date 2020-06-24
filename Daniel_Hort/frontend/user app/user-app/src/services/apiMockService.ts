// @ts-ignore
import {axiosClient} from "./axiosClient";

export const getMockRestaurants = () => {
    return axiosClient.get('./mockRestaurants.json');
}
