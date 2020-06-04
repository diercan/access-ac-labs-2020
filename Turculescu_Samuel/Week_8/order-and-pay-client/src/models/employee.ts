import { Restaurant } from "./restaurant";

export type Employee = {
    id: string,
    firstName: string,
    lastName: string,
    email: string,
    phone: string,
    job: string,
    employeeId: string,
    password: string,
    restaurantId: string,

    restaurant: Restaurant
}