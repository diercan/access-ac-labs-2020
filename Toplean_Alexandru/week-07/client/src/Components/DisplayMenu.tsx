import React, { useState, useEffect } from "react";
import { Menu } from "../Models/Menu";
import { MenuItem } from "../Models/MenuItem";
import { getMenuItems } from "./services/clientApi";
import { handleError } from "./services/apiUtils";
import { useRefetch } from "./services/useRefetch";
import { Container, Row, Col } from "react-bootstrap";
import { MenuItemComponent } from "./MenuItem";

type DisplayMenuProps = {
  menuItems: MenuItem[];
};

export const DisplayMenu = (props: DisplayMenuProps) => {
  return (
    <React.Fragment>
      <Container>
        <Row>
          {props.menuItems.map((menuItem) => (
            <Col md={4}>
              <MenuItemComponent menuItem={menuItem} />
            </Col>
          ))}
        </Row>
      </Container>
    </React.Fragment>
  );
};
