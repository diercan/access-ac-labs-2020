import React from "react";
import "./App.css";
import { NavbarComponent } from "./Components/NavbarComponent";
import { RoutesComponent } from "./routes";
export const App = () => {
  return (
    <React.Fragment>
      <NavbarComponent />
      <RoutesComponent />
    </React.Fragment>
  );
};
