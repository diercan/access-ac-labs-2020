import React from "react";
import { Link } from "react-router-dom";
import { Menu} from "./../models/menu";
import { MenuItem } from "./../models/menuItem";
import {
  Tab,
  Row,
  Col,
  ListGroup
} from "react-bootstrap";

type MenuListProps = {
    menus: Menu[];
  };

  export function MenuList(props: MenuListProps) {
    return (
      <Tab.Container id="list-group-tabs-example" defaultActiveKey="#link1">
        <Row>
          <Col sm={4}>
            <ListGroup>
              {props.menus.map((menu) => {
                return (
                  <ListGroup.Item action href={"/menus/" + menu.id}>
                    {menu.name}
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