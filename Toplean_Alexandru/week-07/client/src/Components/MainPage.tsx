import React, { useState, useEffect } from "react";
import { Switch, Route } from "react-router-dom";
import { Index } from "../Pages/Index";
import { Checkout } from "../Pages/Checkout";
import OrderHistory from "../Pages/OrderHistory";
import { RestaurantVieww } from "../Views/RestaurantView";
import "../css/darkMode.css";
import "../css/main.css";
import { Reviews } from "../Pages/Reviews";
import { PageNotFound } from "../Pages/PageNotFound";
import { Restaurant } from "../Models/Restaurant";
import { Client } from "../Models/Client";
import { Order } from "../Models/Order";
import { OrderItem } from "../Models/OrderItem";

type MainPageProps = {
  setCurrentRestaurant: any;
  order?: Order;
  currentRestaurant?: Restaurant;
  orderItems: OrderItem[];
  setOrderItems: any;
  connectedUser?: Client;
};

export const MainPage = (props: MainPageProps) => {
  return (
    <section>
      <Switch>
        <Route exact path="/" component={Index} />

        <Route exact path="/checkout">
          <Checkout
            setOrderItems={props.setOrderItems}
            orderItems={props.orderItems}
            connectedUser={props.connectedUser}
            order={props.order}
          />
        </Route>

        <Route path="/orderHistory">
          <OrderHistory />
        </Route>
        <Route path="/reviews">
          <Reviews />
        </Route>

        <Route
          exact
          path="/restaurant/:RestaurantName"
          children={({ match }: any) => (
            <RestaurantVieww
              orderItems={props.orderItems}
              setOrderItems={props.setOrderItems}
              match={match}
              order={props.order}
              setCurrentRestaurant={props.setCurrentRestaurant}
            />
          )}
        />

        <Route component={PageNotFound} />
      </Switch>
    </section>
  );
};
