import React from "react";
import { Link } from "react-router-dom";
import { Order } from "./../models/order";
import {
  Tab,
  Row,
  Col,
  ListGroup
} from "react-bootstrap";

type OrdersListProps = {
    orders: Order[];
  };

  export function OrdersList(props: OrdersListProps) {
    return (
      <Tab.Container id="list-group-tabs-example" defaultActiveKey="#link1">
        <Row>
            <Col sm={4}>
            <ListGroup>
                {props.orders.map((order) => {
                return (
                    <ListGroup.Item action href={"/orders/" + order.id}>
                        {order.id}
                    </ListGroup.Item>
                );
                })}
            </ListGroup>
            </Col>
            <Col sm={8}>
            <Tab.Content>
                <Tab.Pane eventKey="#link1">
                
                </Tab.Pane>
                <Tab.Pane eventKey="#link2">
                
                </Tab.Pane>
            </Tab.Content>
            </Col>
        </Row>
    </Tab.Container>
  );
  }