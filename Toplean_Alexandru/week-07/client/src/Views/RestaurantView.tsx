import React from "react";
import ReactDOM from "react-dom";
import { Nav, NavDropdown, Col, Row, Container } from "react-bootstrap";
import { MenuItemComponent } from "../Components/MenuItem";
import { Restaurant } from "../Models/Restaurant";
import MenuItemPic from "../images/mcChicken.jpg";

import "../css/darkMode.css";
import "../css/main.css";

type RestaurantProps = {
  restaurant: Restaurant;
  setOrder?: any;
  currentOrders?: any;
};

type propString = {
  someVal: any;
  eventKey: string;
};

const DisplayMenuItem = (props: propString) => {
  var filteredMenu = props.someVal.restaurant.menus.filter(
    (menu: any) => menu.name == props.eventKey
  );

  return (
    <Row style={{ padding: 0 }}>
      {filteredMenu[0].menuItems.map((menuItemF: any) => (
        <Col lg={4} key={menuItemF.name}>
          <MenuItemComponent
            current={props.someVal.currentOrders}
            setCurrent={props.someVal.setOrder}
            menuItem={menuItemF}
          />
        </Col>
      ))}
    </Row>
  );
};

export const RestaurantVieww = (props: RestaurantProps) => {
  const handleSelect = (eventKey: any) => {
    //alert(`selected ${eventKey}`);
    ReactDOM.render(
      <DisplayMenuItem someVal={props} eventKey={eventKey} />,
      document.getElementById("menuItemSpot")
    );
  };
  var counter = 1;

  return (
    <section>
      <div className="centerAlign topPadding">
        <h1>{props.restaurant.name}</h1>
      </div>

      <Nav
        variant="tabs"
        defaultActiveKey={props.restaurant.menus[0].name}
        onSelect={handleSelect}
      >
        {props.restaurant.menus.map((menu) => (
          <Nav.Item key={menu.id}>
            <Nav.Link eventKey={menu.name}>{menu.name}</Nav.Link>
          </Nav.Item>
        ))}
      </Nav>

      <div id="menuItemSpot">
        <DisplayMenuItem
          someVal={props}
          eventKey={props.restaurant.menus[0].name}
        />
      </div>
    </section>
  );
};
