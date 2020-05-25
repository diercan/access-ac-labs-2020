import React from "react";
import { Container, Row, Col, Card, NavLink } from "react-bootstrap";
import { RatingStarSystem } from "./RatingSystem";
import { Restaurant } from "../Models/Restaurant";
import { BrowserRouter, Switch, Route, Link } from "react-router-dom";
import { Index } from "../Pages/Index";

type RestaurantProps = {
  restaurant: Restaurant;
};

export const RestaurantComponent = (props: RestaurantProps) => {
  return (
    <Card className="upScale">
      <Card.Title
        style={{
          backgroundColor: "#189AD3",
          marginBottom: "0px",
          padding: "10px",
        }}
      >
        <Row>
          <Col xs="auto">{props.restaurant.name}</Col>
          <Col style={{ textAlign: "right" }}>
            <RatingStarSystem numberOfStars={props.restaurant.stars} />
          </Col>
        </Row>
      </Card.Title>
      <Card.Body style={{ padding: "0px", marginTop: "0px" }}>
        <img src={props.restaurant.imageURL} width="100%" />
      </Card.Body>
    </Card>
  );
};
