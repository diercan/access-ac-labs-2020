import React, { Component, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../css/main.css";
import { MenuItem } from "../Models/MenuItem";
import { Form, Button } from "react-bootstrap";
import { Container, Row, Col, Card } from "react-bootstrap";

type CheckoutProps = {
  menuItems: {
    name: string;
    comments?: string;
    quantity?: number;
    price: number;
  }[];
  modifyMenuItems: any;
};

export const Checkout = (props: CheckoutProps) => {
  const deleteItem = (e: any) => {
    e.preventDefault();
    props.modifyMenuItems(
      props.menuItems.filter((menuItem) => menuItem.name != valueToDelete)
    );
  };

  const PlaceOrder = (e: any) => {
    e.preventDefault();
  };

  const [valueToDelete, setValueToDelete] = useState("");
  var counter = 0;
  var totalPrice = 0;
  return (
    <React.Fragment>
      <Container>
        <Row>
          <Col>
            <h1 className="centerAlign topPadding">Checkout </h1>
          </Col>
        </Row>
      </Container>
      <hr className="blackLine" />

      <Row style={{ marginLeft: 0, marginRight: 0 }}>
        <Col>
          <br /> <br />
          <Card>
            <Card.Header
              style={{ backgroundColor: "#189AD3", textAlign: "center" }}
            >
              <h2> Checkout Items</h2>
            </Card.Header>
            <Card.Body>
              {props.menuItems.length == 1 &&
              props.menuItems[0].name.length == 0 ? (
                <h3 className="centerAlign">
                  <br />
                  -No menu items currently selected-
                </h3>
              ) : (
                <table style={{ width: "100%" }}>
                  <thead>
                    <tr className="bottomBorder">
                      <td>Menu Item</td>
                      <td>Quantity</td>
                      <td>Comments</td>
                      <td>Price</td>
                      <td>Options</td>
                    </tr>
                  </thead>
                  <tbody>
                    {props.menuItems
                      .filter((item) => item.name.length > 0)
                      .map((item) => (
                        <tr
                          key={item.name}
                          style={{
                            backgroundColor:
                              counter++ % 2 == 1 ? "lightblue" : "white",
                          }}
                        >
                          <td>{item.name}</td>
                          <td>{item.quantity}</td>
                          <td>{item.comments}</td>
                          <td>{item.price} Lei</td>
                          <td>
                            <Form onSubmit={deleteItem}>
                              <button
                                type="submit"
                                onClick={() => setValueToDelete(item.name)}
                              >
                                Remove Item?
                              </button>
                            </Form>
                          </td>
                        </tr>
                      ))}
                  </tbody>
                </table>
              )}

              <Row className="topPadding">
                <Col md={{ span: 3, offset: 8 }}></Col>
              </Row>
            </Card.Body>
          </Card>
          <Card className="topMargin">
            <Card.Header
              style={{ backgroundColor: "#189AD3", textAlign: "center" }}
            >
              <h2>Please add your credentials to confirm checkout</h2>
            </Card.Header>
            <Card.Body>
              <Form onSubmit={PlaceOrder}>
                <Form.Row>
                  <Form.Group as={Col} controlId="formGridEmail">
                    <Form.Label>First Name</Form.Label>
                    <Form.Control type="text" placeholder="John" />
                  </Form.Group>

                  <Form.Group as={Col} controlId="formGridPassword">
                    <Form.Label>Last Name</Form.Label>
                    <Form.Control type="text" placeholder="Doe" />
                  </Form.Group>
                </Form.Row>
                <Form.Group controlId="formGridAddress1">
                  <Form.Label>Table Number</Form.Label>
                  <Form.Control placeholder="1" />
                </Form.Group>
                <Form.Group id="formGridCheckbox">
                  <Form.Check
                    type="checkbox"
                    label="Agree to terms and conditions"
                  />
                </Form.Group>
                <Button type="submit" style={{ backgroundColor: "#189AD3" }}>
                  Place Order
                </Button>
              </Form>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </React.Fragment>
  );
};
