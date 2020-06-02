import { Navbar, Nav, NavItem, NavDropdown, Badge } from "react-bootstrap";
import React, { CSSProperties, useState, useEffect } from "react";
import { Link, BrowserRouter, Switch, Route, NavLink } from "react-router-dom";
import { Index } from "../Pages/Index";
import { Checkout } from "../Pages/Checkout";
import { OrderHistory } from "../Pages/OrderHistory";

import CartPicture from "../images/3551020411578889023.svg";

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
  numberOfCartItems: number;
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
              {props.connectedUser ? (
                <NavLink className="nav-link" to="/orderHistory">
                  Order History
                </NavLink>
              ) : null}

              <NavLink className="nav-link" to="/reviews">
                Reviews
              </NavLink>
            </Nav>

            <Nav>
              <NavLink to="/checkout">
                <span className="cartImage">
                  <Badge
                    pill
                    variant="success"
                    style={{
                      width: "20px",
                      height: "20px",
                      marginLeft: "-12px",
                    }}
                  >
                    {props.numberOfCartItems != 0
                      ? props.numberOfCartItems
                      : null}
                  </Badge>
                </span>
              </NavLink>
              {props.connectedUser ? (
                userIsConnected ? (
                  <NavLink
                    className="nav-link"
                    to="#"
                    style={{ marginLeft: "20px" }}
                  >
                    {props.connectedUser.username}
                  </NavLink>
                ) : (
                  <p>no</p>
                )
              ) : (
                <NavLink
                  style={{ marginLeft: "20px" }}
                  className="nav-link"
                  to="#"
                  onClick={() => setOpenLogin(true)}
                >
                  Login
                </NavLink>
              )}
            </Nav>
          </Navbar.Collapse>
        </Navbar>
      </header>
      {openLogin ? (
        <LoginModal
          setShow={setOpenLogin}
          setConnectedUser={props.setConnectedUser}
          show={openLogin}
          order={props.order}
          setOrder={props.setOrder}
          currentRestaurant={props.currentRestaurant}
        />
      ) : null}
    </React.Fragment>
  );
};
