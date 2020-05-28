import React from "react";
import ReactDOM from "react-dom";
import "bootstrap/dist/css/bootstrap.min.css";

import { DrawNavbar } from "./Components/Navbar";
import { BrowserRouter, Switch, Route } from "react-router-dom";

import { Index } from "./Pages/Index";
import { Checkout } from "./Pages/Checkout";
import OrderHistory from "./Pages/OrderHistory";
import { MainPage } from "./Components/MainPage";
import "./css/darkMode.css";
import "./css/main.css";
import { PageNotFound } from "./Pages/PageNotFound";
const root = document.getElementById("root");
const element = (
  <React.Fragment>
    <BrowserRouter>
      <DrawNavbar />
      <Switch>
        <MainPage />
      </Switch>
    </BrowserRouter>
  </React.Fragment>
);

ReactDOM.render(element, root);
