import "bootstrap/dist/css/bootstrap.min.css";
import './App.css';
import React from 'react';
import Header from "./components/Header"
import { Route, Switch } from "react-router-dom"
import Navbar from "./components/Navbar";
import RestaurantPage from "./components/RestaurantPage";
import Cart from "./components/Cart";
import NotFoundPage from "./components/NotFoundPage";
import { ErrorReporter } from "./components/ErrorReporter";

export const App = () => {
  return (
    <div className="container-fluid">
      <Header />
      <Navbar />
      <Switch>
        <Route path="/" exact component={RestaurantPage} />
        <Route path="/cart" component={Cart} />
        <Route component={NotFoundPage} />
      </Switch>
      <ErrorReporter></ErrorReporter>
    </div>
  );
};
