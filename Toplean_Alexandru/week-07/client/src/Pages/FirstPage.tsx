import { useState, useEffect } from "react";
import { Client } from "../Models/Client";
import { Restaurant } from "../Models/Restaurant";
import { Order } from "../Models/Order";
import { DrawNavbar } from "../Components/Navbar";
import { MainPage } from "../Components/MainPage";
import React from "react";
import { BrowserRouter } from "react-router-dom";
import { OrderItem } from "../Models/OrderItem";

export const FirstPage = () => {
  const [connectedUser, setConnectedUser] = useState<Client>();
  const [currentRestaurant, setCurrentRestaurant] = useState<Restaurant>();
  const [order, setOrder] = useState<Order>();
  const [orderItems, setOrderItems] = useState<OrderItem[]>([]);

  var [numberOfOrderItems, setNumberOfOrderItems] = useState(0);

  useEffect(() => {
    setNumberOfOrderItems(orderItems.length);
  });

  return (
    <React.Fragment>
      <BrowserRouter>
        <DrawNavbar
          connectedUser={connectedUser}
          setConnectedUser={setConnectedUser}
          order={order}
          setOrder={setOrder}
          currentRestaurant={currentRestaurant}
          numberOfCartItems={numberOfOrderItems ? numberOfOrderItems : 0}
        />
        <MainPage
          order={order}
          currentRestaurant={currentRestaurant}
          setCurrentRestaurant={setCurrentRestaurant}
          orderItems={orderItems}
          setOrderItems={setOrderItems}
        />
      </BrowserRouter>
    </React.Fragment>
  );
};
