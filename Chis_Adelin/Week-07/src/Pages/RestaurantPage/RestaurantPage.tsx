import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { MenuItem } from "../../Models/MenuItemModel";
import { Container } from "react-bootstrap";
import { MenuItemsListComponent } from "./Components/MenuItemsList";
import { DailyMenuComponent } from "./Components/DailyMenu";
import { MenuItems } from "../../Data/MenuItems";

type RestaurantPageProps = {
  name: string;
  dailyMenu: MenuItem;
};
export const RestaurantPageComponent = (props: RestaurantPageProps) => {
  return (
    <Container>
      <h1 className="text-center"> {props.name}</h1>
      <DailyMenuComponent item={props.dailyMenu} />
      <MenuItemsListComponent items={MenuItems} />
    </Container>
  );
};
