import React, { useState, useEffect } from "react";
import { HeaderBannerComponent } from "./Components/HeaderBanner";
import { RestaurantSelectorListComponent } from "./Components/RestaurantSelectorList";
import { GetRestaurants } from "../../Services/RestaurantsService";
import { Restaurant } from "../../Models/RestaurantModel";
import { Button } from "react-bootstrap";
import { LoadingComponent } from "../../Components/LoadingComponent";

export const LandingPageComponent = () => {
  const [restaurants, setRestaurants] = useState<Restaurant[]>();
  useEffect(() => {
    GetRestaurants().then((response) => {
      if (response) setRestaurants(response.data);
    });
  }, []);

  if(restaurants)
  return (
    <React.Fragment>
      <HeaderBannerComponent />
      <RestaurantSelectorListComponent restaurants={restaurants} />
    </React.Fragment>
  );
  else 
  return <LoadingComponent />;
};
