import axios from "axios";
import { axiosClient } from "./axiosClient";
import {handleError} from "./apiUtils";

export const GetRestaurants = () =>
{
    return axiosClient.get("restaurants").catch(handleError);
}