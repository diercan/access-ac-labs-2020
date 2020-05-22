import React, { Component, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { RestaurantComponent } from "../Components/RestaurantComponent";

import { Container, Row, Col } from "react-bootstrap";
import { NavLink, Link } from "react-router-dom";
import { Restaurant } from "../Models/Restaurant";

type IndexProps = {
  restaurants: Restaurant[];
  selectedRestaurant?: any;
};

export const Index = (props: IndexProps) => {
  const restaurants = props.restaurants;

  function selectRestaurant(restaurant: any) {
    return props.selectedRestaurant(restaurant);
  }

  return (
    <React.Fragment>
      <h2 className="centerAlign topPadding">
        Please choose one of the following restaurants
      </h2>
      <Container>
        <Row>
          {restaurants.map((restaurantt) => (
            <Col lg={4} className="topPadding" key={restaurantt.id}>
              <Link
                onClick={(param) => selectRestaurant(restaurantt)}
                to={"/restaurant/" + restaurantt.name}
              >
                <RestaurantComponent restaurant={restaurantt} />
              </Link>
            </Col>
          ))}
        </Row>
      </Container>
    </React.Fragment>
  );
};
