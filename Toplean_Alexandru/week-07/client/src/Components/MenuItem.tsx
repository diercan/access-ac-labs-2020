import React, { useState } from "react";
import { MenuItem } from "../Models/MenuItem";
import {
  Card,
  Row,
  Col,
  Accordion,
  Button,
  FormLabel,
  Container,
  Form,
} from "react-bootstrap";
import { RatingStarSystem } from "./RatingSystem";
import { MenuItemAlergens } from "./MenuItemComponents/Alergens";
import { MenuItemIngredients } from "./MenuItemComponents/Ingredients";

type MenuItemProps = {
  menuItem: MenuItem;
};

export const MenuItemComponent = (props: MenuItemProps) => {
  const [qty, setQty] = useState("");
  const [com, setCom] = useState("");

  var randomNumber = Math.random() * 1000;
  return (
    <Card className="topMargin" style={{ fontWeight: "bold" }}>
      <Card.Header
        style={{
          marginBottom: "0px",
          backgroundColor: "#189AD3",
          color: "white",
        }}
      >
        <Row>
          <Col md={6}>
            {props.menuItem.Name} <br /> {props.menuItem.Price} lei
          </Col>
          <Col lg={6} style={{ verticalAlign: "right" }}>
            <RatingStarSystem numberOfStars={5} />
          </Col>
        </Row>
      </Card.Header>
      <Card.Body>
        <Row>
          <Col lg={8}>
            <MenuItemIngredients ingredients={props.menuItem.Ingredients} />
          </Col>
          <Col lg={4}>
            <img src={props.menuItem.Image} width="100%" />
          </Col>
        </Row>
        <hr style={{ borderColor: "black" }} />
        <Row>
          <Col>
            <Form>
              <Row>
                <Col md={4}>
                  <label>Quantity</label>
                </Col>
                <Col md={8}>
                  <Form.Control
                    placeholder="Quantity..."
                    value={qty}
                    onChange={(e) => {
                      setQty(e.target.value);
                    }}
                  />
                </Col>
              </Row>
              <Row>
                <Col>
                  <label>Customize?(optional)</label> <br />
                  <Form.Control
                    placeholder="Example: No onions"
                    value={com}
                    onChange={(e) => setCom(e.target.value)}
                  />
                </Col>
              </Row>
              <Row className="topPadding">
                <Col md={6}>
                  <Accordion>
                    <Accordion.Toggle
                      style={{ backgroundColor: "#189AD3" }}
                      as={Button}
                      eventKey={randomNumber.toString()}
                    >
                      View Alergens
                    </Accordion.Toggle>
                    <Accordion.Collapse eventKey={randomNumber.toString()}>
                      {props.menuItem.Alergens != null ? (
                        <MenuItemAlergens alergens={props.menuItem.Alergens} />
                      ) : (
                        <p>None</p>
                      )}
                    </Accordion.Collapse>
                  </Accordion>
                </Col>
                <Col md={{ span: 6 }}>
                  <Button style={{ backgroundColor: "#189AD3" }} type="submit">
                    Add to Order
                  </Button>
                </Col>
              </Row>
            </Form>
          </Col>
        </Row>
      </Card.Body>
    </Card>
  );
};
