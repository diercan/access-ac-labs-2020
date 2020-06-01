import axios from "axios";
import { axiosClient } from "./axiosClient";

export const GetRestaurants = () =>
{
    return axiosClient.get("restaurants");
}