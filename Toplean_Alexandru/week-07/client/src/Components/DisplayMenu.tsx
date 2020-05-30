import React, { useState, useEffect } from "react";
import { Menu } from "../Models/Menu";
import { MenuItem } from "../Models/MenuItem";
import { getMenuItems } from "./services/clientApi";
import { handleError } from "./services/apiUtils";
import { useRefetch } from "./services/useRefetch";
import { Container, Row, Col } from "react-bootstrap";
import { MenuItemComponent } from "./MenuItem";
import { Order } from "../Models/Order";

type DisplayMenuProps = {
  menuItems: MenuItem[];
  order?: Order;
};

export const DisplayMenu = (props: DisplayMenuProps) => {
  return (
    <React.Fragment>
      <Container>
        <Row>
          {props.menuItems.map((menuItem) => (
            <Col md={4}>
              <MenuItemComponent menuItem={menuItem} order={props.order} />
            </Col>
          ))}
        </Row>
      </Container>
    </React.Fragment>
  );
};
