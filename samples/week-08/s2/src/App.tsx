import "bootstrap/dist/css/bootstrap.min.css";
import React from "react";
import { Route, Switch } from "react-router-dom";
import Header from "./components/Header";
import HomePage from "./components/HomePage";
import MenuPage from "./components/MenuPage";
import CurrentOrderPage from "./components/CurrentOrderPage";
import NotFoundPage from "./components/NotFoundPage";

export const App = () => {
  return (
    <div className="container-fluid">
      <Header />
      <Route path="/" exact component={HomePage} />
      <Route path="/menu" component={MenuPage} />
      <Route path="/current-order" component={CurrentOrderPage} />
    </div>
  );
};
