import { axiosClient } from "./axiosClient";
import { MenuItem } from "../Models/MenuItemModel";


export const PostMenuItem = (MenuItem : MenuItem, Quantity: number) =>
{
    return axiosClient.post("order", {MenuItem, Quantity}).then(response => {console.log(response)});
}
export const GetOrderStatus = () =>
{
    return axiosClient.get("order/status");
}
export const FinishOrder = () =>
{
    return axiosClient.post("order/finish").then(response => {console.log(response)}, (error) => { console.log(error) });
}