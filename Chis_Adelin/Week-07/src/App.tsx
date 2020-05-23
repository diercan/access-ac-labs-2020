import React from "react";
import "./App.css";
import { MenuItem } from "./Models/MenuItemModel";
import { RestaurantPageComponent } from "./Components/RestaurantPage";
import { NavbarComponent } from "./Components/NavbarComponent";

const MenuItem1: MenuItem = {
  name: "Pizza Capricioasa",
  ingredients: "Sos de pizza, șunculița, mozzarella, ciuperci champignon, salam italian, pește anchois, măsline, capere aromate, oregano parfumat",
  allergens: "Lactoză, Gluten",
  image: require("./assets/img/meniul-zilei.jpg"),
  price: 20
};

export const App = () => {
  return (
    <React.Fragment>
      <NavbarComponent />
      <RestaurantPageComponent name="Pizzeria Napoleon" dailyMenu={MenuItem1} />
    </React.Fragment>
  );
};
