import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import navImage from "../assets/img/nav-gif.gif";
import { Navbar, Nav } from "react-bootstrap";

export const NavbarComponent = () => {
    return (
        <Navbar expand="lg">
        <Navbar.Brand href="#home">
          <img className="ml-5" alt="logo" src={navImage} width="50px"/>
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="ml-auto">
            <Nav.Link href="#home">Restaurante</Nav.Link>
            <Nav.Link href="#link">Meniul zilei</Nav.Link>
            <Nav.Link href="#link">Comanda ta</Nav.Link>
            <Nav.Link href="#link">Contact</Nav.Link>
            <Nav.Link href="#link">Cont</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
}