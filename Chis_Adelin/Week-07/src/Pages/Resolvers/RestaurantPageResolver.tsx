import React, { useState } from "react";
import { RouteComponentProps } from "react-router-dom";
import { restaurants } from "../../Data/Restaurants";
import { Restaurant } from "../../Models/RestaurantModel";
import { RestaurantPageComponent } from "../RestaurantPage/RestaurantPage";
import { DailyMenuComponent } from "../RestaurantPage/Components/DailyMenu";
import { DailyMenu } from "../../Data/DailyMenu";

type RestaurantPageResolverProps = {
  slug: string;
};

interface RestaurantPageProps
  extends RouteComponentProps<RestaurantPageResolverProps> {}

function RestaurantPageResolver(props: RestaurantPageProps) {
  const selectedRestaurant = restaurants.find((restaurant) => {
    return restaurant.slug == props.match.params.slug;
  });
  if (selectedRestaurant)
    return (
      <RestaurantPageComponent
        name={selectedRestaurant.name}
        dailyMenu={selectedRestaurant.dailyMenu}
      />
    );
  // TODO: Redirect to landing page/or to notfound component and delete unused imports
  else return <DailyMenuComponent item={DailyMenu} />;
}

export default RestaurantPageResolver;
