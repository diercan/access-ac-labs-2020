import React from "react";
import { HeaderBannerComponent } from "./Components/HeaderBanner";
import { restaurants } from "../../Data/Restaurants";
import { RestaurantSelectorListComponent } from "./Components/RestaurantSelectorList";

export const LandingPageComponent = () => {
  return (
    <React.Fragment>
      <HeaderBannerComponent />
      <RestaurantSelectorListComponent restaurants={restaurants} />
    </React.Fragment>
  );
};
