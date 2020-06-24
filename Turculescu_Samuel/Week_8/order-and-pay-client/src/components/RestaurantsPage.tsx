import React, { useState, useEffect } from "react";
import { RestaurantsList } from "./RestaurantsList";
import { Restaurant } from "./../models/restaurant";
import { getRestaurants } from "./../services/clientApi";

function RestaurantsPage() {
    const [restaurants, setRestaurants] = useState<Restaurant[]>();    
    useEffect(() => {
      getRestaurants().then((response) => {
        if (response) setRestaurants(response.data);
      });
    }, []);
    return !restaurants ? (
      <div>Loading...</div>
    ) : (
      <> 
        <RestaurantsList restaurants={restaurants} />
      </>
    );
  }

  export default RestaurantsPage;

