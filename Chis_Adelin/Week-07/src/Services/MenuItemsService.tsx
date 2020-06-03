import { axiosClient } from "./axiosClient";


export const GetMenuItems = () =>
{
    return axiosClient.get("menuitems");
}
