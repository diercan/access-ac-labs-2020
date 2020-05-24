import React from "react";
import "./App.css";
import { RestaurantPageComponent } from "./Components/RestaurantPage";
import { NavbarComponent } from "./Components/NavbarComponent";
import { DailyMenu } from "./Data/DailyMenu";
export const App = () => {
  return (
    <React.Fragment>
      <NavbarComponent />
      <RestaurantPageComponent name="Pizzeria Napoleon" dailyMenu={DailyMenu} />
    </React.Fragment>
  );
};
