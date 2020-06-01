import React, { Component, useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../css/main.css";
import { MenuItem } from "../Models/MenuItem";
import { Form, Button } from "react-bootstrap";
import { Container, Row, Col, Card } from "react-bootstrap";
import { OrderItem } from "../Models/OrderItem";
import {
  getMenuItemById,
  getMenuItemsById,
} from "../Components/services/clientApi";
import { handleError } from "../Components/services/apiUtils";
import { useRefetch } from "../Components/services/useRefetch";

type DisplayItem = {
  name: string;
  quantity: number;
  comment?: string;
  price: number;
};

type CheckoutProps = {
  orderItems: OrderItem[];

  setOrderItems: any;
};

export const Checkout = (props: CheckoutProps) => {
  //const [checkoutItems, setCheckoutItems] = useState<DisplayItem[]>([]);
  var checkoutItems: any = [];
  const [menuItems, setMenuItems] = useState<any[]>([]);
  const [refetch, setRefetch] = useRefetch();
  const [currentCheckout, setCurrentCheckout] = useState<any[]>();
  const [valueToDelete, setValueToDelete] = useState<string>();

  useEffect(() => {
    if (props.orderItems.length > 0) {
      const outstr = props.orderItems.map((item) => item.menuItemId).join(";");
      getMenuItemsById(outstr)
        .then((response) => {
          setMenuItems(response.data);
        })
        .catch((error) => {
          alert("getMenuItemsById error");
          console.log(handleError(error));
        });
    }
  }, [props.orderItems]);

  useEffect(() => {
    if (menuItems.length > 0) {
      for (var order of props.orderItems) {
        checkoutItems.push({
          name: menuItems.filter(
            (menuItem) => menuItem.id == order.menuItemId
          )[0].name,
          quantity: order.quantity,
          price: menuItems.filter(
            (menuItem) => menuItem.id == order.menuItemId
          )[0].price,
          comment: order.comment,
        });
      }
    }
    console.log(checkoutItems);
    setCurrentCheckout(checkoutItems);
  }, [menuItems, refetch]);

  useEffect(() => {
    // left here. TODO: Correctly remove an order item
    if (valueToDelete) {
      let itemToDelete = menuItems.filter(
        (item) => item.name == valueToDelete
      )[0];
      if (menuItems) {
        setCurrentCheckout(
          menuItems.filter((items) => items.id != itemToDelete.id)
        );
        console.log(menuItems.filter((items) => items.id != itemToDelete.id));
        setRefetch();
      }
    }
  }, [valueToDelete]);

  const submitCart = () => {};

  const PlaceOrder = (e: any) => {
    e.preventDefault();
  };

  var counter = 0;
  var totalPrice = 0;

  return currentCheckout ? (
    <React.Fragment>
      {console.log(currentCheckout)}
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
              {currentCheckout.length == 0 ? (
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
                      <td>Price</td>

                      <td>Comments</td>
                      <td>Options</td>
                    </tr>
                  </thead>
                  <tbody>
                    {currentCheckout.map((item: any) => (
                      <tr
                        key={item.name}
                        style={{
                          backgroundColor:
                            counter++ % 2 == 1 ? "lightblue" : "white",
                        }}
                      >
                        <td>{item.name}</td>
                        <td>{item.quantity}</td>
                        <td>{item.price}</td>
                        <td>{item.comment} Lei</td>
                        <td>
                          <Form>
                            <button onClick={() => setValueToDelete(item.name)}>
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
                <Button
                  onClick={submitCart}
                  style={{ backgroundColor: "#189AD3" }}
                >
                  Place Order
                </Button>
              </Form>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </React.Fragment>
  ) : (
    <p>Loading {checkoutItems.length}</p>
  );
};
