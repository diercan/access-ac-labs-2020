import { Navbar, Nav } from "react-bootstrap";
import React from "react";
import { NavLink } from "react-router-dom";

import { DarkMode } from "./DarkMode";

type ConnectionProps = {
  employeeIsConnected: boolean;
  setEmployeeConnection: any;
};

export const DrawNavbar = (props: ConnectionProps) => {
  return (
    <React.Fragment>
      <header>
        <Navbar bg="dark" expand="lg" variant="dark" style={{ color: "white" }}>
          <NavLink
            className="navbar-brand"
            to={props.employeeIsConnected ? "/viewOrders" : "/login"}
          >
            Order And Pay
          </NavLink>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
              <NavLink className="nav-link" to="/createRestaurant">
                Create Restaurant
              </NavLink>

              <NavLink className="nav-link" to="/McDonalds/controlPanel">
                Control Panel
              </NavLink>
              <NavLink className="nav-link" to="/viewOrders">
                View Orders
              </NavLink>
              {props.employeeIsConnected ? (
                <NavLink className="nav-link" to="/login">
                  Log Out
                </NavLink>
              ) : (
                <NavLink className="nav-link" to="/login">
                  Log In
                </NavLink>
              )}
            </Nav>

            <DarkMode />
          </Navbar.Collapse>
        </Navbar>
      </header>
    </React.Fragment>
  );
};
