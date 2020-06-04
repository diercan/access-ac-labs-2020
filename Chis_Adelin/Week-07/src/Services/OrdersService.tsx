import { axiosClient } from "./axiosClient";
import { MenuItem } from "../Models/MenuItemModel";
import {handleError} from "./apiUtils";


export const PostMenuItem = (MenuItem : MenuItem, Quantity: number) =>
{
    return axiosClient.post("order", {MenuItem, Quantity});
}
export const GetOrderStatus = () =>
{
    return axiosClient.get("order/status");
}
export const FinishOrder = () =>
{
    return axiosClient.get("order/finish")
        .then(response => {console.log(response)}, (error) => { console.log(error) })
        .catch(handleError);
}