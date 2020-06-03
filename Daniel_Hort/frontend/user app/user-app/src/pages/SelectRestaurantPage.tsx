import {useEffect, useState} from "react";
import {RestaurantModel} from "../models/RestaurantModel";
import React from "react";
import {getMockRestaurants} from "../services/apiMockService";

function SelectRestaurantPage(){
    const [restaurants, setRestaurants] = useState<RestaurantModel[]>()
    useEffect(() => {
        getMockRestaurants().then(res => {
            if(res) setRestaurants(res.data);
        })
    }, []);

    return !restaurants
        ? (
            <p>Loading...</p>
        ) : (
            <React.Fragment>
                <h1>Restaurants</h1>
                {restaurants.map((res) => {
                    return (<p key={res.id}>{res.name}</p>);
                })}
            </React.Fragment>
    )
}

export default SelectRestaurantPage;
