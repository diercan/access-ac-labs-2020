import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { MenuItem } from "../../Models/MenuItemModel";
import { Container } from "react-bootstrap";
import { MenuItemsListComponent } from "./Components/MenuItemsList";
import { DailyMenuComponent } from "./Components/DailyMenu";
import { MenuItems } from "../../Data/MenuItems";
import { GetMenuItems } from "../../Services/MenuItemsService";
import { LoadingComponent } from "../../Components/LoadingComponent";

type RestaurantPageProps = {
  name: string;
  dailyMenu: MenuItem;
};
export const RestaurantPageComponent = (props: RestaurantPageProps) => {
  const [MenuItems, setMenuItems] = useState<MenuItem[]>();
  useEffect(() => {
    GetMenuItems().then((response) => {
      if (response) setMenuItems(response.data);
    });
  }, []);
  if (MenuItems)
    return (
      <Container>
        <h1 className="text-center"> {props.name}</h1>
        <DailyMenuComponent item={props.dailyMenu} />
        <MenuItemsListComponent items={MenuItems} />
      </Container>
    );
  else return <LoadingComponent/>;
};
