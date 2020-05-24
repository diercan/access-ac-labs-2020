import { Navbar, Nav, NavItem, NavDropdown } from "react-bootstrap";
import React, { CSSProperties } from "react";
import { Link, BrowserRouter, Switch, Route, NavLink } from "react-router-dom";
import { Index } from "../Pages/Index";
import { Checkout } from "../Pages/Checkout";
import OrderHistory from "../Pages/OrderHistory";

import { DarkMode } from "./DarkMode";

export const DrawNavbar = () => {
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
            </Nav>
            <DarkMode />
          </Navbar.Collapse>
        </Navbar>
      </header>
    </React.Fragment>
  );
};
