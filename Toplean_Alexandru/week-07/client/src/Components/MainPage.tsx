import React, { useState } from "react";
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

type MainPageProps = {
  connectedUser: Client;
  order?: Order;
};

export const MainPage = (props: MainPageProps) => {
  const [checkout, setCheckoutItems] = useState([
    {
      name: "",
      price: 0,
      quantity: 0,
      comments: "",
    },
  ]);
  const [selectedRestaurant, setSelectedRestaurant] = useState<Restaurant[]>();

  return (
    <section>
      <Switch>
        <Route exact path="/" component={Index} />

        <Route exact path="/checkout">
          <Checkout menuItems={checkout} modifyMenuItems={setCheckoutItems} />
        </Route>

        <Route path="/orderHistory">
          <OrderHistory />
        </Route>
        <Route path="/reviews">
          <Reviews />
        </Route>

        <Route
          path="/restaurant/:RestaurantName"
          component={({ match }: any) => (
            <RestaurantVieww match={match} order={props.order} />
          )}
        />

        <Route component={PageNotFound} />
      </Switch>
    </section>
  );
};
