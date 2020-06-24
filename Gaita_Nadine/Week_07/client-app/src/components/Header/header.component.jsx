import React from "react";
import { Navbar, Nav } from "react-bootstrap";
import { Link } from 'react-router-dom';

const Header = () => {
  return (
    <div>
      <Navbar bg="dark" variant="dark">
        <Link to='/'>
          <Navbar.Brand>Order & Pay</Navbar.Brand>
        </Link>
        <Nav className="ml-auto">
          <Nav.Link href="#features">Current Order</Nav.Link>
          <Nav.Link href="#pricing">History</Nav.Link>
          <Nav.Link href="#signin">Sign-in</Nav.Link>
        </Nav>
      </Navbar>
    </div>
  );
};

export default Header;
