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
const root = document.getElementById("root");

const App = () => {
  const [connectedUser, setConnectedUser] = useState<Client>();
  const [currentRestaurant, setCurrentRestaurant] = useState<Restaurant>();
  const [order, setOrder] = useState<Order>();

  return (
    <React.Fragment>
      <BrowserRouter>
        <DrawNavbar
          connectedUser={connectedUser}
          setConnectedUser={setConnectedUser}
          order={order}
          setOrder={setOrder}
          currentRestaurant={currentRestaurant}
        />
        <MainPage connectedUser={connectedUser as Client} order={order} />
      </BrowserRouter>
    </React.Fragment>
  );
};

ReactDOM.render(<App />, root);
