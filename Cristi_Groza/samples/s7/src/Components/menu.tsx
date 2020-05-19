import React from "react";
import { MenuItemComponent } from "./menu-item";
import { MenuItem } from "../Models/menu-item";

const carbonara: MenuItem = {
  name: "Spaghete carbonara",
  price: 24,
};

const risotto: MenuItem = {
  name: "Risotto cu fructe de mare",
  price: 34,
};

export const Menu = () => (
  <React.Fragment>
    <MenuItemComponent item={carbonara}></MenuItemComponent>
    <MenuItemComponent item={risotto}></MenuItemComponent>
  </React.Fragment>
);
