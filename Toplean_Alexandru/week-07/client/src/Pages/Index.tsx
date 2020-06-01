import React, { Component, useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { RestaurantComponent } from "../Components/RestaurantComponent";

import { Container, Row, Col } from "react-bootstrap";
import { NavLink, Link } from "react-router-dom";
import { Restaurant } from "../Models/Restaurant";
import { getRestaurants } from "../Components/services/clientApi";
import { Order } from "../Models/Order";

export const Index = () => {
  //const restaurants = props.restaurants;
  const [restaurants, setRestaurants] = useState<Restaurant[]>();
  useEffect(() => {
    getRestaurants().then(
      (response) => {
        if (response) setRestaurants(response.data);
      },
      (error) => {
        if (error) console.error(error);
      }
    );
  }, []);

  return !restaurants ? (
    <p>Loading...</p>
  ) : (
    <React.Fragment>
      <h2 className="centerAlign topPadding">
        Please choose one of the following restaurants
      </h2>
      <Container>
        <Row>
          {(restaurants as Restaurant[]).map((restaurantt) => (
            <Col lg={4} className="topPadding" key={restaurantt.id}>
              <NavLink
                to={"/restaurant/" + restaurantt.name}
                className="noHyperLinks"
              >
                <RestaurantComponent restaurant={restaurantt} />
              </NavLink>
            </Col>
          ))}
        </Row>
      </Container>
    </React.Fragment>
  );
};
