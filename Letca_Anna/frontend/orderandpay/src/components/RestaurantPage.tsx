import React, { useState, useEffect } from "react";
import { getRestaurant, getAllRestaurants } from "../services/clientApi";
import { Restaurant } from "../models/restaurant";
import RestaurantList from "./RestaurantList";

function RestaurantPage() {
  const [restaurants, setRestaurants] = useState<Restaurant[]>();
  useEffect(() => {
    getAllRestaurants().then((response) => {
      if (response) setRestaurants(response.data);
    });
  }, []);
  return !restaurants ? (
    <div>Loading...</div>
  ) : (
      <RestaurantList restaurants={restaurants} />
    );
}

export default RestaurantPage;