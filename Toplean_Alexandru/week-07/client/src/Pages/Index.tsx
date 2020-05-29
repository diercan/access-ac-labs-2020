import React, { Component, useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { RestaurantComponent } from "../Components/RestaurantComponent";

import { Container, Row, Col } from "react-bootstrap";
import { NavLink, Link } from "react-router-dom";
import { Restaurant } from "../Models/Restaurant";
import { getRestaurants } from "../Components/services/clientApi";

type IndexProps = {
  restaurants: Restaurant[];
  selectedRestaurant?: any;
};

export const Index = (props: IndexProps) => {
  //const restaurants = props.restaurants;

  const [restaurants, setRestaurants] = useState<Restaurant[]>([
    {
      id: 0,
      name: "",
      stars: 5,
      image: "",
      menus: [],
      orders: [],
      employees: [],
    },
  ]);
  useEffect(() => {
    getRestaurants().then(
      (response) => {
        console.log(response);
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
