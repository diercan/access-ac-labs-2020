import React, { useState, useEffect } from "react";
import ReactDOM from "react-dom";
import { Nav, NavDropdown, Col, Row, Container } from "react-bootstrap";
import { MenuItemComponent } from "../Components/MenuItem";
import { Restaurant } from "../Models/Restaurant";
import MenuItemPic from "../images/mcChicken.jpg";

import "../css/darkMode.css";
import "../css/main.css";
import { Menu } from "../Models/Menu";
import { getMenus } from "../Components/services/clientApi";
import { handleError } from "../Components/services/apiUtils";
import { MenuItem } from "../Models/MenuItem";
import { DisplayMenu } from "../Components/DisplayMenu";

type RestaurantProps = {
  restaurant: Restaurant;
  setOrder?: any;
  currentOrders?: any;
};

type propString = {
  someVal: any;
  eventKey: string;
};

/* const DisplayMenuItem = (props: propString) => {
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
}; */

export const RestaurantVieww = (props: any) => {
  const [menusGot, setMenusGot] = useState(false);
  const [menus, setMenus] = useState<Menu[]>();
  const [selectedMenu, setSelectedMenu] = useState<Menu>();
  const [menuItems, getMenuItems] = useState<MenuItem[]>();

  useEffect(() => {
    if (selectedMenu) {
      console.log(selectedMenu);
    }
  }, [selectedMenu]);

  useEffect(() => {
    getMenus(props.match.params.RestaurantName)
      .then((response) => {
        if (response) setMenus(response.data);
        setMenusGot(true);
        console.log(response.data);
      })
      .catch((error) => {
        alert("getMenus Error");
        console.log(handleError(error));
      });
  }, [menusGot]);

  var counter = 1;

  return !menus ? (
    <p>Loading...</p>
  ) : (
    <section>
      <div className="centerAlign topPadding">
        <h1>{props.match.params.RestaurantName}</h1>
      </div>

      <Nav
        variant="tabs"
        defaultActiveKey={menus[0].Name}
        onSelect={() => {
          setSelectedMenu(menus[0]);
        }}
      >
        {menus.map((menu: Menu) => (
          <Nav.Item
            onClick={() => {
              setSelectedMenu(menu);
            }}
            key={menu.Id}
          >
            <Nav.Link eventKey={menu.Name}>{menu.Name}</Nav.Link>
          </Nav.Item>
        ))}
      </Nav>

      <div id="menuItemSpot">
        {selectedMenu ? (
          <DisplayMenu menuItems={selectedMenu.MenuItem as MenuItem[]} />
        ) : (
          <DisplayMenu menuItems={(menus[0] as Menu).MenuItem} />
        )}
      </div>
    </section>
  );
};
