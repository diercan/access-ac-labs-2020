import React, { useState, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import { MenuDetails } from "../models/menu";
import { getMenu } from "./../services/employeeApi";

type MenuRouteProps = {
  menuId: string;
};

interface MenuPageProps extends RouteComponentProps<MenuRouteProps> {}

function MenuPage(props: MenuPageProps) {
  const [menu, setMenu] = useState<MenuDetails>();
  useEffect(() => {
    getMenu(props.match.params.menuId).then((response) => {
      if (response) setMenu(response.data);
    });
  }, [props.match.params.menuId]);
  return !menu ? (
    <div>Loading... </div>
  ) : (
    <>
      <h2>{menu.name}</h2>

      {menu.menuItems.map((item) => {
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
