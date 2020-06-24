import React, { useState, useEffect } from "react";
import { Nav } from "react-bootstrap";
import { Restaurant } from "../Models/Restaurant";

import "../css/darkMode.css";
import "../css/main.css";
import { Menu } from "../Models/Menu";
import { getMenus, getRestaurant } from "../Components/services/clientApi";
import { handleError } from "../Components/services/apiUtils";
import { MenuItem } from "../Models/MenuItem";
import { DisplayMenu } from "../Components/DisplayMenu";
import { Order } from "../Models/Order";
import { OrderItem } from "../Models/OrderItem";
import { Client } from "../Models/Client";

type RestaurantProps = {
  match: any;
  order?: Order;
  orderItems: OrderItem[];
  setOrderItems: any;
  setCurrentRestaurant: any;
  connectedUser?: Client;
};

export const RestaurantVieww = (props: RestaurantProps) => {
  const [menusGot, setMenusGot] = useState(false);
  const [menus, setMenus] = useState<Menu[]>();
  const [selectedMenu, setSelectedMenu] = useState<Menu>();
  const [menuItems, getMenuItems] = useState<MenuItem[]>();

  useEffect(() => {
    getRestaurant(props.match.params.RestaurantName)
      .then((response) => props.setCurrentRestaurant(response.data.Name))
      .catch((error) => {
        alert("getRestaurantError");
        console.log(handleError(error));
      });

    getMenus(props.match.params.RestaurantName)
      .then((response) => {
        if (response) setMenus(response.data);
        setMenusGot(true);
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
          <DisplayMenu
            menuItems={selectedMenu.MenuItem as MenuItem[]}
            order={props.order}
            orderItems={props.orderItems}
            //setNumberOfOrderItems={props.setNumberOfOrderItems}
            setOrderItems={props.setOrderItems}
            //numberOfOrderItems={props.numberOfOrderItems}
          />
        ) : (
          <DisplayMenu
            menuItems={(menus[0] as Menu).MenuItem}
            order={props.order}
            orderItems={props.orderItems}
            //setNumberOfOrderItems={props.setNumberOfOrderItems}
            setOrderItems={props.setOrderItems}
            //numberOfOrderItems={props.numberOfOrderItems}
          />
        )}
      </div>
    </section>
  );
};
