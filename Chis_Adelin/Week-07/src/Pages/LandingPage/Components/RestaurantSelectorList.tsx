import React from "react";
import { Row, Container } from "react-bootstrap";
import { RestaurantSelectorComponent } from "./RestaurantSelectorPreview";
import { Restaurant } from "../../../Models/RestaurantModel";

type RestaurantSelectorProps = {
  restaurants: Restaurant[];
};

export const RestaurantSelectorListComponent = (
  props: RestaurantSelectorProps
) => {
  return (
    <Container className="m-5 mx-auto">
      <h1 className="text-center m-5" id="link">
        Alege restaurantul:
      </h1>
      <Row className="mt-5 mb-5 d-flex align-items-center">
        {props.restaurants.map((restaurant) => (
          <RestaurantSelectorComponent
            name={restaurant.name}
            slug={restaurant.slug}
            image={restaurant.logo}
          />
        ))}
      </Row>
    </Container>
  );
};
