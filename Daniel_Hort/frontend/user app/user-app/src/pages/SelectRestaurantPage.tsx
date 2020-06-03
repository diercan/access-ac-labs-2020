import {useEffect, useState} from "react";
import {RestaurantModel} from "../models/RestaurantModel";
import React from "react";
import {getMockRestaurants} from "../services/apiMockService";
import RestaurantComponent from "../components/RestaurantComponent";
import ListGroup from "react-bootstrap/ListGroup";

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
                <header>
                    <h5 className="text-secondary">Please choose a restaurant from whom you want to order</h5>
                    <p>Use the map or select from the list below</p>
                </header>
                <ListGroup id="restaurantList">
                    {restaurants.map((res) => {
                        return (<RestaurantComponent key={res.id} restaurant={res} />);
                    })}
                </ListGroup>
            </React.Fragment>
    )
}

export default SelectRestaurantPage;
