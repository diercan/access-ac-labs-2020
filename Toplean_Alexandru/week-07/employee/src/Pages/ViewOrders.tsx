import React, { useState, useEffect } from "react";
import { Redirect } from "react-router";
import { OrderItem } from "../Components/OrderItems";
import { Container, Row, Col } from "react-bootstrap";
import { Order } from "../Models/Order";
import { getOrders } from "../Components/services/employeeApi";
import { handleError } from "../Components/services/apiUtils";
import { ContentLoading } from "../Components/ContentLoadingComponent";
import { useRefetch } from "../Components/services/useRefetch";

type ViewOrdersProps = {
  employeeIsConnected: boolean;
  restaurant: string;
};

export const ViewOrders = (props: ViewOrdersProps) => {
  const [orders, setOrders] = useState<Order[]>();
  const [refetch, setRefetch] = useRefetch();
  useEffect(() => {
    getOrders(props.restaurant)
      .then((response) => {
        if (response) setOrders(response.data.order);
        console.log(response.data.order);
      })
      .catch((error) => {
        alert("getOrdersError");
        console.log(handleError(error));
      });
  }, [refetch]);
  if (props.employeeIsConnected === false) {
    alert("You must be logged in to view orders");
    return <Redirect to="/"></Redirect>;
  }
  return !orders ? (
    <ContentLoading />
  ) : (
    <React.Fragment>
      <Container>
        {orders.filter((order: Order) => order.completed === false).length ==
        0 ? (
          <Row>
            <Col>
              <h4>No current orders</h4>
            </Col>
          </Row>
        ) : (
          <React.Fragment>
            <Row>
              <Col>
                <h1 className="centerAlign">Current Orders!</h1>
              </Col>
            </Row>
            <Row>
              <Col>
                {(orders as any[])
                  .filter(
                    (order: any) =>
                      order.completed == false && order.orderItems.length > 0
                  )
                  .map((order: any) => (
                    <OrderItem
                      setRefetch={setRefetch}
                      key={order.id as string}
                      id={order.id}
                      order={order as Order}
                      tableNumber={order.tableNumber}
                      orderItems={order.orderItems}
                      completed={order.completed}
                    />
                  ))}
              </Col>
            </Row>
          </React.Fragment>
        )}
        {/* {orders.filter((order) => order.Completed == false).length == 0 ? (
          <Row>
            <Col>
              <h4>No Completed Orders currently recorded</h4>
            </Col>
          </Row>
        ) : ( */}
        <React.Fragment>
          <Row className="topPadding">
            <Col>
              <h1 className="centerAlign">Order History</h1>
            </Col>
          </Row>
          <Row>
            <Col>
              {(orders as any)
                .filter(
                  (order: any) =>
                    order.completed === true && order.orderItems.length > 0
                )
                .map((order: any) => (
                  <OrderItem
                    key={order.id as string}
                    id={order.id}
                    order={order as Order}
                    setRefetch={setRefetch}
                    tableNumber={order.tableNumber}
                    orderItems={order.orderItems}
                    completed={order.completed}
                  />
                ))}
            </Col>
          </Row>
        </React.Fragment>
        {/*  )}  */}
      </Container>
    </React.Fragment>
  );
};
