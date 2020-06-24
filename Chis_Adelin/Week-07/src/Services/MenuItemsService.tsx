import { axiosClient } from "./axiosClient";
import {handleError} from "./apiUtils";


export const GetMenuItems = () =>
{
    return axiosClient.get("menuitems").catch(handleError);
}
