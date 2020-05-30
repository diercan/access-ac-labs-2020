import { Navbar, Nav, NavItem, NavDropdown } from "react-bootstrap";
import React, { CSSProperties, useState, useEffect } from "react";
import { Link, BrowserRouter, Switch, Route, NavLink } from "react-router-dom";
import { Index } from "../Pages/Index";
import { Checkout } from "../Pages/Checkout";
import { OrderHistory } from "../Pages/OrderHistory";

import { DarkMode } from "./DarkMode";
import { Client } from "../Models/Client";
import { LoginModal } from "./Modals/LoginModal";
import { Order } from "../Models/Order";
import { Restaurant } from "../Models/Restaurant";

type NavbarProps = {
  connectedUser?: Client;
  setConnectedUser: any;
  order?: Order;
  setOrder: any;
  currentRestaurant?: Restaurant;
};

export const DrawNavbar = (props: NavbarProps) => {
  const [openLogin, setOpenLogin] = useState(false);
  const [userIsConnected, setUserIsConnected] = useState(false);
  useEffect(() => {
    setUserIsConnected(true);
  }, [props.connectedUser]);

  return (
    <React.Fragment>
      <header>
        <Navbar bg="dark" expand="lg" variant="dark" style={{ color: "white" }}>
          <NavLink className="navbar-brand" to="/">
            Order And Pay
          </NavLink>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
              <NavLink className="nav-link" to="/checkout">
                Checkout
              </NavLink>

              <NavLink className="nav-link" to="/orderHistory">
                Order History
              </NavLink>
              <NavLink className="nav-link" to="/reviews">
                Reviews
              </NavLink>
            </Nav>
            {props.connectedUser ? (
              userIsConnected ? (
                <p>{props.connectedUser.username}</p>
              ) : (
                <p>no</p>
              )
            ) : (
              <Nav>
                <NavLink
                  className="nav-link"
                  to="#"
                  onClick={() => setOpenLogin(true)}
                >
                  Login
                </NavLink>
              </Nav>
            )}
          </Navbar.Collapse>
        </Navbar>
      </header>
      {openLogin ? (
        <LoginModal
          setShow={setOpenLogin}
          setConnectedUser={props.setConnectedUser}
          show={openLogin}
          setOrder={props.setOrder}
          currentRestaurant={props.currentRestaurant}
        />
      ) : null}
    </React.Fragment>
  );
};
