import axios from "axios";

export const axiosEmployee = axios.create({
  baseURL: "https://localhost:5001/orderandpay/employee",
});
