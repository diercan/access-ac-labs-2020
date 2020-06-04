import React from "react";
import { NavLink, Link } from "react-router-dom";
import { 
    Navbar, 
    Nav, 
    Button 
} from "react-bootstrap";

function Header() {
    return (
        <Navbar bg="light" expand="lg">
        <Navbar.Brand href="#home">Order & Pay</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto">
            <Nav.Link as={NavLink} exact to="/">Home</Nav.Link>
            <Nav.Link as={NavLink} to="/menus">Menus</Nav.Link>
            <Nav.Link as={NavLink} to="/orders">Orders</Nav.Link>
            <Nav.Link as={NavLink} to="/current-order">Current Order</Nav.Link>
            <Nav.Link href="#about">About</Nav.Link>
          </Nav>
        </Navbar.Collapse>
        <Button variant="primary" as={Link} to="/login">Log In</Button>{' '}
        <Button variant="danger" as={Link} to="/">Log Out</Button>{' '}
      </Navbar>
    );
  }
  
  export default Header;