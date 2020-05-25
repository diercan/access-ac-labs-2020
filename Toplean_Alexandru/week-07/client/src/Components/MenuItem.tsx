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
  current?: any;
  setCurrent?: any;
};

export const MenuItemComponent = (props: MenuItemProps) => {
  const [qty, setQty] = useState("");
  const [com, setCom] = useState("");

  const addToCheckout = (e: any) => {
    e.preventDefault();
    if (props.current.length == 1 && props.current[0].name.length == 0) {
      props.setCurrent([
        {
          name: props.menuItem.name,
          quantity: qty,
          comments: com,
          price: props.menuItem.price,
        },
      ]);
    } else {
      props.setCurrent([
        ...props.current,
        {
          name: props.menuItem.name,
          quantity: qty,
          comments: com,
          price: props.menuItem.price,
        },
      ]);
    }
    console.log(props.current);
  };
  var randomNumber = Math.random() * 1000;
  return (
    <Container>
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
              {props.menuItem.name} <br /> {props.menuItem.price} lei
            </Col>
            <Col lg={6} style={{ verticalAlign: "right" }}>
              <RatingStarSystem numberOfStars={5} />
            </Col>
          </Row>
        </Card.Header>
        <Card.Body>
          <Row>
            <Col lg={6}>
              <MenuItemIngredients ingredients={props.menuItem.ingredients} />
            </Col>
            <Col lg={6}>
              <img src={props.menuItem.imageURL} width="100%" />
            </Col>
          </Row>
          <hr style={{ borderColor: "black" }} />
          <Row>
            <Col>
              <Form onSubmit={addToCheckout}>
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
                        {props.menuItem.alergens != null ? (
                          <MenuItemAlergens
                            alergens={props.menuItem.alergens}
                          />
                        ) : (
                          <p>None</p>
                        )}
                      </Accordion.Collapse>
                    </Accordion>
                  </Col>
                  <Col md={{ span: 6 }}>
                    <Button
                      style={{ backgroundColor: "#189AD3" }}
                      type="submit"
                    >
                      Add to Order
                    </Button>
                  </Col>
                </Row>
              </Form>
            </Col>
          </Row>
        </Card.Body>
      </Card>
    </Container>
  );
};
