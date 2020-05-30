import React, { useState, useEffect } from "react";
import { Nav } from "react-bootstrap";
import { Restaurant } from "../Models/Restaurant";

import "../css/darkMode.css";
import "../css/main.css";
import { Menu } from "../Models/Menu";
import { getMenus } from "../Components/services/clientApi";
import { handleError } from "../Components/services/apiUtils";
import { MenuItem } from "../Models/MenuItem";
import { DisplayMenu } from "../Components/DisplayMenu";
import { Order } from "../Models/Order";

type RestaurantProps = {
  match: any;
  order?: Order;
};

export const RestaurantVieww = (props: RestaurantProps) => {
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
          <DisplayMenu
            menuItems={selectedMenu.MenuItem as MenuItem[]}
            order={props.order}
          />
        ) : (
          <DisplayMenu
            menuItems={(menus[0] as Menu).MenuItem}
            order={props.order}
          />
        )}
      </div>
    </section>
  );
};
