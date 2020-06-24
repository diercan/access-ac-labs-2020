import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { Navbar, Nav } from "react-bootstrap";
import navLogo from "../assets/img/nav-gif.gif"

export const NavbarComponent = () => {
  return (
    <Navbar expand="lg">
      <Navbar.Brand href="#home">
        <img className="ml-5" alt="logo" src={navLogo} width="50px"/>
      </Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="ml-auto">
          <Nav.Link href="#restaurants">Restaurante</Nav.Link>
          <Nav.Link href="order">Comanda ta</Nav.Link>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
}