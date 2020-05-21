import React from "react";
import { MenuItem } from "../Models/MenuItem";
import {
  Card,
  Row,
  Col,
  Accordion,
  Button,
  FormLabel,
  Container,
} from "react-bootstrap";
import { RatingStarSystem } from "./RatingSystem";

type MenuItemProps = {
  menuItem: MenuItem;
};

export const MenuItemComponent = (props: MenuItemProps) => {
  return (
    <Container>
      <Card>
        <Card.Header>
          <Row>
            <Col md={6}>
              {props.menuItem.name} - {props.menuItem.price} lei
            </Col>
            <Col lg={6}>
              <RatingStarSystem numberOfStars={5} />
            </Col>
          </Row>
          <Row>
            <Col>
              <Accordion>
                <div className="btn btn-primary" style={{ width: "100%" }}>
                  <Accordion.Toggle as={FormLabel} eventKey="0">
                    View Alergens
                  </Accordion.Toggle>
                </div>
                <Accordion.Collapse eventKey="0">
                  <div>Hello! I'm the body</div>
                </Accordion.Collapse>
              </Accordion>
            </Col>
          </Row>
        </Card.Header>
        <Card.Body>
          <Row>
            <Col>
              <img src={props.menuItem.imageURL} />
            </Col>
          </Row>
        </Card.Body>
      </Card>
    </Container>
  );
};
