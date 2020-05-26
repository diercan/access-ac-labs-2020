import React, { useState } from "react";
import { menu } from "./../models/mockData";
import { RouteComponentProps } from "react-router-dom";

type MenuRouteProps = {
  menuId: string;
};

interface MenuPageProps extends RouteComponentProps<MenuRouteProps> {}

function MenuPage(props: MenuPageProps) {
  const selectedMenu = menu[props.match.params.menuId];
  return (
    <>
      <h2>{selectedMenu.name}</h2>

      {selectedMenu.menuItems.map((item) => {
        return (
          <div key={item.id}>
            {item.name} - {item.price} lei
          </div>
        );
      })}
    </>
  );
}

export default MenuPage;
