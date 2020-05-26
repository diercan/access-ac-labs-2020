import "bootstrap/dist/css/bootstrap.min.css";
import React from "react";
import { Route, Switch } from "react-router-dom";
import Header from "./components/Header";
import HomePage from "./components/HomePage";
import MenusPage from "./components/MenusPage";
import MenuPage from "./components/MenuPage";
import OrdersPage from "./components/OrdersPage";
import NotFoundPage from "./components/NotFoundPage";
import { ErrorReporter } from "./components/ErrorReporter";

export const App = () => {
  return (
    <div className="container-fluid">
      <Header />
      <Switch>
        <Route path="/" exact component={HomePage} />
        <Route path="/menus" component={MenusPage} />
        <Route path="/menu/:menuId" component={MenuPage} />
        <Route path="/orders" component={OrdersPage} />
        <Route component={NotFoundPage} />
      </Switch> 
      <ErrorReporter></ErrorReporter>
    </div>
  );
};
