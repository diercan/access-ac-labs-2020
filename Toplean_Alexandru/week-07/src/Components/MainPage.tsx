import React from "react";
import { Switch, Route } from "react-router-dom";
import { Index } from "../Pages/Index";
import Checkout from "../Pages/Checkout";
import OrderHistory from "../Pages/OrderHistory";
import { RestaurantView } from "../Views/RestaurantView";

export const MainPage = () => {
  return (
    <div id="workspace">
      <Route exact path="/" component={Index}></Route>
      <Route path="/checkout" component={Checkout}></Route>
      <Route path="/orderHistory" component={OrderHistory}></Route>
      <Route path="/:RestaurantName" component={RestaurantView}></Route>
    </div>
  );
};
