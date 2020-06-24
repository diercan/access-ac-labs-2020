import React from "react";
import { Menu } from "../Models/Menu";
import { MenuItem } from "../Models/MenuItem";
import { getMenuItems } from "./services/clientApi";
import { handleError } from "./services/apiUtils";
import { useRefetch } from "./services/useRefetch";
import { Container, Row, Col } from "react-bootstrap";
import { MenuItemComponent } from "./MenuItem";
import { Order } from "../Models/Order";
import { OrderItem } from "../Models/OrderItem";
import { Client } from "../Models/Client";

type DisplayMenuProps = {
  menuItems: MenuItem[];
  order?: Order;
  orderItems: OrderItem[];
  setOrderItems: any;
};

export const DisplayMenu = (props: DisplayMenuProps) => {
  return (
    <React.Fragment>
      <Container>
        <Row>
          {props.menuItems.map((menuItem) => (
            <Col md={4} key={menuItem.Id?.toString()}>
              <MenuItemComponent
                menuItem={menuItem}
                order={props.order}
                orderItems={props.orderItems}
                setOrderItems={props.setOrderItems}
              />
            </Col>
          ))}
        </Row>
      </Container>
    </React.Fragment>
  );
};
