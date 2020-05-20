import React from "react";
import { MenuItem } from "./../Models/menu-item";

type MenuItemProps = {
  item: MenuItem;
};

export const MenuItemComponent = (props: MenuItemProps) => {
  return (
    <div>
      <span style={{ color: "red" }}>
        {props.item.name} - {props.item.price} lei
      </span>
    </div>
  );
};
