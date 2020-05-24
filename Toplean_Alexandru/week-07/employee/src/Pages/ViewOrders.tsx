import React from "react";
import { Redirect } from "react-router";
import { OrderItem } from "../Components/OrderItems";
import { Container, Row, Col } from "react-bootstrap";

type ViewOrdersProps = {
  employeeIsConnected: boolean;
};

const orders = [
  {
    id: 1,
    tableNumber: 4,
    menuItems: [
      {
        name: "Pizza Pepperoni",
        quantity: 2,
        comment: "Doresc cu ulei de masline",
      },
      {
        name: "Clatite cu Finetti",
        quantity: 1,
        comment: "Si banane",
      },
      {
        name: "Inghetata din Ciocolata Belgiana",
        quantity: 1,
        comment: "-",
      },
    ],
    completed: false,
  },
  {
    id: 2,
    tableNumber: 7,
    menuItems: [
      {
        name: "Pizza Pepperoni",
        quantity: 2,
        comment: "Doresc cu ulei de masline",
      },
      {
        name: "Clatite cu Finetti",
        quantity: 1,
        comment: "Si banane",
      },
      {
        name: "Inghetata din Ciocolata Belgiana",
        quantity: 1,
        comment: "-",
      },
    ],
    completed: false,
  },
];

export const ViewOrders = (props: ViewOrdersProps) => {
  if (props.employeeIsConnected == false) {
    alert("You must be logged in to create a menu");
    return <Redirect to="/"></Redirect>;
  }
  return (
    <React.Fragment>
      <Container>
        <Row>
          <Col>
            <h1 className="centerAlign">Create a new menu item!</h1>
          </Col>
        </Row>
        <Row>
          <Col>
            {orders.map((order) => (
              <OrderItem
                id={order.id}
                tableNumber={order.tableNumber}
                menuItems={order.menuItems}
              />
            ))}
          </Col>
        </Row>
      </Container>
    </React.Fragment>
  );
  //return orders.map((order) => <OrderItem id={order.id} />);
};
