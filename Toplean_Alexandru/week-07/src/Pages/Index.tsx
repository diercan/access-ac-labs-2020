import React, { Component, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import restaurantPic from "../images/caruso.jpg";

import { RestaurantComponent } from "../Components/RestaurantComponent";

import { Container, Row, Col } from "react-bootstrap";
import { NavLink, Link } from "react-router-dom";
import { Restaurant } from "../Models/Restaurant";

export const Index = () => {
  const [restaurants, _] = useState([
    {
      id: 1,
      name: "McDonalds",
      stars: 5,
      imageURL: restaurantPic,
      menus: [
        { id: 1, name: "Chicken", menuType: "Meat", specialMenu: false },
        { id: 2, name: "Fish", menuType: "Meat", specialMenu: false },
        { id: 3, name: "Drinks", menuType: "Drinks", specialMenu: false },
      ],
    },
    {
      id: 2,
      name: "Caruso",
      stars: 4,
      imageURL: restaurantPic,
      menus: [],
    },
    {
      id: 3,
      name: "Caruso",
      stars: 3,
      imageURL: restaurantPic,
      menus: [],
    },
  ]);

  return (
    <React.Fragment>
      <h2 className="centerAlign topPadding">
        Please choose one of the following restaurants
      </h2>
      <Container>
        <Row>
          {restaurants.map((restaurantt) => (
            <Col lg={4} className="topPadding">
              <Link
                to={{
                  pathname: "/" + restaurantt.name,
                  state: { restaurantt },
                }}
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
