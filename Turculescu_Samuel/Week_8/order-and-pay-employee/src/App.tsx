import React from 'react';
import { Route, Switch } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import './App.css';
import Header from "./components/Header";
import HomePage from "./components/HomePage";
import LoginPage from "./components/LoginPage";
import SignupPage from "./components/SignupPage";
import MenusPage from "./components/MenusPage";
import MenuPage from "./components/MenuPage";
import OrdersPage from "./components/OrdersPage";
import OrderPage from "./components/OrderPage";
import RestaurantPage from "./components/RestaurantPage";
import NotFoundPage from "./components/NotFoundPage";
import { ErrorReporter } from "./components/ErrorReporter";

export const App = () => {
  return (
    <div>
      <Header />
      <Route path="/" exact component={HomePage} />
      <Route path="/restaurant/:restaurantName" component={RestaurantPage} />    
      <Route path="/menus" component={MenusPage} />   
      <Route path="/menus/:menuId" component={MenuPage} />
      <Route path="/orders" component={OrdersPage} />   
      <Route path="/orders/:orderId" component={OrderPage} />

      <Route path="/login" component={LoginPage} />  
      <Route path="/signup" component={SignupPage} />   
      <ErrorReporter></ErrorReporter>
    </div>
  );
}

export default App;
