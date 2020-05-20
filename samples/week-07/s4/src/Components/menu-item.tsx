import React from "react";
import { MenuItem } from "./../Models/menu-item";
import style from "./menu-item.module.css";

type MenuItemProps = {
  item: MenuItem;
};

export const MenuItemComponent = (props: MenuItemProps) => {
  return (
    <div>
      <span className={style["menu-item-text"]}>
        {props.item.name} - {props.item.price} lei
      </span>
    </div>
  );
};
