import React, { useState, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import { Order } from "./../models/order";
import { OrderItem } from "./../models/orderItem";
import { getOrderItems } from "./../services/employeeApi";
import { Button, Table } from "react-bootstrap";
import { useRefetch } from "../services/useRefetch";

type OrderRouteProps = {
  orderId: string;
};

interface OrderPageProps extends RouteComponentProps<OrderRouteProps> {}

function OrderPage(props: OrderPageProps) {
  const [orderItems, setOrderItems] = useState<OrderItem[]>();
  const [refetch, setRefetch] = useRefetch();
  
  useEffect(() => {
    getOrderItems(props.match.params.orderId).then((response) => {
      if (response) setOrderItems(response.data);
    });
  }, [props.match.params.orderId, refetch]);

  return !orderItems ? (
    <div>Loading... </div>
  ) : (
    <>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Quantity</th>
            <th>Special Requests</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>
          {orderItems.map((item, index) => {
            return (
              <tr key={item.id}>
                <td>{index + 1}</td>
                <td>{item.name}</td>
                <td>{item.quantity}</td>
                <td>{item.specialRequests}</td>
                <td>{item.price} lei</td>               
              </tr>
            );
          })}
        </tbody>
      </Table>
    </>
  );
}

export default OrderPage;
