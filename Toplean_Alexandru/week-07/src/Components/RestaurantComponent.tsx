import React from "react";
import { Container, Row, Col, Card } from "react-bootstrap";
import { RatingStarSystem } from "./RatingSystem";
import { Restaurant } from "../Models/Restaurant";

type RestaurantProps = {
  restaurant: Restaurant;
};

export const RestaurantComponent = (props: RestaurantProps) => {
  return (
    <Container>
      <Card className="upScale">
        <Card.Title
          style={{
            backgroundColor: "lightgray",
            marginBottom: "0px",
            padding: "10px",
          }}
        >
          <Row>
            <Col xs="auto">{props.restaurant.restaurantName}</Col>
            <Col style={{ textAlign: "right" }}>
              <RatingStarSystem numberOfStars={props.restaurant.stars} />
            </Col>
          </Row>
        </Card.Title>
        <Card.Body style={{ padding: "0px", marginTop: "0px" }}>
          <img src={props.restaurant.imageURL} width="100%" />
        </Card.Body>
      </Card>
    </Container>
  );
};
