import React from "react";
import { NavLink } from "react-router-dom";

function Header() {
  const activeStyle = { color: "orange" };
  return (
    <nav>
      <NavLink activeStyle={activeStyle} exact to="/">
        Home
      </NavLink>
      {" | "}
      <NavLink activeStyle={activeStyle} to="/menus">
       Menus 
      </NavLink>
      {" | "}
      <NavLink activeStyle={activeStyle} to="/current-order">
        Current Order
      </NavLink>
    </nav>
  );
}

export default Header;
