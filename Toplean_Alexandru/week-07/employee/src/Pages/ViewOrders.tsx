import React, { useState, useEffect } from "react";
import { Redirect } from "react-router";
import { OrderItem } from "../Components/OrderItems";
import { Container, Row, Col } from "react-bootstrap";
import { Order } from "../Models/Order";
import { getOrders } from "../Components/services/employeeApi";
import { handleError } from "../Components/services/apiUtils";
import { ContentLoading } from "../Components/ContentLoadingComponent";

type ViewOrdersProps = {
  employeeIsConnected: boolean;
  restaurant: string;
};

export const ViewOrders = (props: ViewOrdersProps) => {
  const [orders, setOrders] = useState<Order[]>();
  useEffect(() => {
    getOrders(props.restaurant)
      .then((response) => {
        if (response) setOrders(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        alert("getOrdersError");
        console.log(handleError(error));
      });
  }, []);
  if (props.employeeIsConnected === false) {
    alert("You must be logged in to view orders");
    return <Redirect to="/"></Redirect>;
  }
  return !orders ? (
    <ContentLoading />
  ) : (
    <React.Fragment>
      <Container>
        {orders.filter((order) => order.Completed === false).length == 0 ? (
          <Row>
            <Col>
              <h4>No current orders</h4>
            </Col>
          </Row>
        ) : (
          <React.Fragment>
            <Row>
              <Col>
                <h1 className="centerAlign">Create a new menu item!</h1>
              </Col>
            </Row>
            <Row>
              <Col>
                {(orders as any[])
                  .filter((order: any) => order.completed === false)
                  .map((order: any) => (
                    <OrderItem
                      key={order.id as string}
                      id={order.id}
                      tableNumber={order.tableNumber}
                      menuItems={order.menuItems}
                      completed={order.completed}
                    />
                  ))}
              </Col>
            </Row>
          </React.Fragment>
        )}
        {orders.filter((order) => order.Completed === false).length == 0 ? (
          <Row>
            <Col>
              <h4>No Completed Orders currently recorded</h4>
            </Col>
          </Row>
        ) : (
          <React.Fragment>
            <Row className="topPadding">
              <Col>
                <h1 className="centerAlign">Order History</h1>
              </Col>
            </Row>
            <Row>
              <Col>
                {(orders as any)
                  .filter((order: any) => order.completed === true)
                  .map((order: any) => (
                    <OrderItem
                      key={order.id as string}
                      id={order.id}
                      tableNumber={order.tableNumber}
                      menuItems={order.menuItems}
                      completed={order.completed}
                    />
                  ))}
              </Col>
            </Row>
          </React.Fragment>
        )}
      </Container>
    </React.Fragment>
  );
};
