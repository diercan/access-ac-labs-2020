import React, { useState } from "react";
import { Switch, Route } from "react-router-dom";
import { Index } from "../Pages/Index";
import { Checkout } from "../Pages/Checkout";
import OrderHistory from "../Pages/OrderHistory";
import { RestaurantVieww } from "../Views/RestaurantView";
import restaurantPic from "../images/caruso.jpg";
import mcChicken from "../images/mcChicken.jpg";
import "../css/darkMode.css";
import "../css/main.css";
import { Reviews } from "../Pages/Reviews";
import { PageNotFound } from "../Pages/PageNotFound";

export const MainPage = () => {
  const [checkout, setCheckoutItems] = useState([
    {
      name: "",
      price: 0,
      quantity: 0,
      comments: "",
    },
  ]);
  const [selectedRestaurant, setSelectedRestaurant] = useState({
    id: 0,
    name: "",
    stars: 0,
    imageURL: "",
    menus: [],
  });

  const restaurants = [
    {
      id: 1,
      name: "McDonalds",
      stars: 5,
      imageURL: restaurantPic,
      menus: [
        {
          id: 1,
          name: "Chicken",
          menuType: "Meat",
          specialMenu: false,
          menuItems: [
            {
              id: 1,
              name: "McChicken",
              ingredients: "McChicken;Cartofi prajiti;Coca cola",
              price: 15.99,
              imageURL: mcChicken,
            },
            {
              id: 2,
              name: "McPuisor",
              ingredients: "McPuisor;Cartofi prajiti;Coca cola",
              price: 8.99,
              imageURL: mcChicken,
            },
          ],
        },
        {
          id: 2,
          name: "Fish",
          menuType: "Meat",
          specialMenu: false,
          menuItems: [
            {
              id: 1,
              name: "Fish fingers",
              ingredients: "Fish Fingers;Cartofi prajiti;Coca cola",
              price: 15.99,
              imageURL: mcChicken,
            },
          ],
        },
        {
          id: 3,
          name: "Drinks",
          menuType: "Drinks",
          specialMenu: false,
          menuItems: [],
        },
      ],
      employees: [],
      orders: [],
    },
    {
      id: 2,
      name: "Caruso",
      stars: 4,
      imageURL: restaurantPic,
      menus: [
        {
          id: 1,
          name: "Chicken",
          menuType: "Meat",
          specialMenu: false,
          menuItems: [],
        },
        {
          id: 2,
          name: "Fish",
          menuType: "Meat",
          specialMenu: false,
          menuItems: [],
        },
        {
          id: 3,
          name: "Drinks",
          menuType: "Drinks",
          specialMenu: false,
          menuItems: [],
        },
      ],
      employees: [],
      orders: [],
    },
    {
      id: 3,
      name: "Caruso",
      stars: 3,
      imageURL: restaurantPic,
      menus: [],
    },
  ];

  return (
    <section>
      <Switch>
        <Route exact path="/" component={Index}>
          {/* <Index
            restaurants={restaurants}
            selectedRestaurant={setSelectedRestaurant}
          /> */}
        </Route>

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
          component={RestaurantVieww}
        ></Route>

        <Route component={PageNotFound} />
      </Switch>
    </section>
  );
};
