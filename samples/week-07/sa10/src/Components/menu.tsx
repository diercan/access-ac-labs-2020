import React from "react";
import { MenuItemComponent } from "./menu-item";
import { MenuItem } from "../Models/menu-item";

type MenuProps = {
  items: MenuItem[];
};
export const Menu = (props: MenuProps) => (
  <React.Fragment>
    {props.items.map((item, index) => (
      <MenuItemComponent key={index} item={item} />
    ))}
  </React.Fragment>
);
