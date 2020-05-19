import React, { Component } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import restaurantPic from "../images/caruso.jpg";

import { RestaurantComponent } from "../Components/RestaurantComponent";

import { Container, Row, Col } from "react-bootstrap";

class Index extends Component {
  render() {
    return (
      <React.Fragment>
        <h2 className="centerAlign topPadding">
          Please choose one of the following restaurants
        </h2>
        <Container>
          <Row>
            <Col lg={4} className="topPadding">
              <RestaurantComponent
                restaurant={{
                  restaurantName: "Caruso",
                  stars: 5,
                  imageURL: restaurantPic,
                }}
              />
            </Col>

            <Col lg={4} className="topPadding">
              <RestaurantComponent
                restaurant={{
                  restaurantName: "Caruso",
                  stars: 4,
                  imageURL: restaurantPic,
                }}
              />
            </Col>

            <Col lg={4} className="topPadding">
              <RestaurantComponent
                restaurant={{
                  restaurantName: "Caruso",
                  stars: 4,
                  imageURL: restaurantPic,
                }}
              />
            </Col>
          </Row>
        </Container>
      </React.Fragment>
    );
  }
}
export default Index;
