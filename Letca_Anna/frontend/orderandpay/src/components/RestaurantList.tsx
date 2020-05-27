import React from "react";
import { Link } from "react-router-dom";
import { Restaurant } from "../models/restaurant";
import RestaurantCard from "./RestaurantCard";

type RestaurantListProps = {
    restaurants: Restaurant[];
};

export function RestaurantList(props: RestaurantListProps) {
    const restaurantsArray=Array.from(props.restaurants);
    console.log(restaurantsArray);
    return (
        <>
            <div className="container mb-4 pb-2">
                <div className="row">
                   {
                       restaurantsArray.map((restaurant)=>
                       {
                           return (
                               <RestaurantCard key={restaurant.id} restaurant={restaurant}/>
                           );
                       }
                       )
                   } 
                </div>
            </div>
        </>
    );
}

export default RestaurantList;