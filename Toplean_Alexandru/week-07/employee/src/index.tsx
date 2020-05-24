import React, { useState } from "react";
import ReactDOM from "react-dom";
import "bootstrap/dist/css/bootstrap.min.css";

import { DrawNavbar } from "./Components/Navbar";
import { BrowserRouter, Switch, Route } from "react-router-dom";

import { MainPage } from "./Components/MainPage";
import "./css/darkMode.css";
import "./css/main.css";
const root = document.getElementById("root");

const element = (
  <React.Fragment>
    <BrowserRouter>
      <MainPage />
    </BrowserRouter>
  </React.Fragment>
);

ReactDOM.render(element, root);
