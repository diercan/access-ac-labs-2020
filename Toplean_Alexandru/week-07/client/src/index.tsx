import React, { useState } from "react";
import ReactDOM from "react-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import { DrawNavbar } from "./Components/Navbar";
import { BrowserRouter } from "react-router-dom";
import { MainPage } from "./Components/MainPage";
import "./css/darkMode.css";
import "./css/main.css";
import { Client } from "./Models/Client";
import { Order } from "./Models/Order";
import { Restaurant } from "./Models/Restaurant";
import { OrderItem } from "./Models/OrderItem";
import { FirstPage } from "./Pages/FirstPage";
const root = document.getElementById("root");

const MainApp = () => {
  return <FirstPage />;
};

ReactDOM.render(<MainApp />, root);
