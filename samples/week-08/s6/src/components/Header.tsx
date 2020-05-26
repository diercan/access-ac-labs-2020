import React from "react";
import { NavLink } from "react-router-dom";
import { Navbar, Nav } from "react-bootstrap";

function Header() {
  const activeStyle = { color: "orange" };
  return (
    <Navbar bg="light" expand="lg" style={{marginBottom:"20px"}}>
      <Navbar.Brand>Order & Pay</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-auto">
          <Nav.Link as={NavLink} activeStyle={activeStyle} exact to="/" >Home</Nav.Link>
          <Nav.Link as={NavLink} activeStyle={activeStyle} to="/menus">Menus</Nav.Link>
          <Nav.Link as={NavLink} activeStyle={activeStyle} to="/orders">Orders</Nav.Link>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
}

export default Header;
