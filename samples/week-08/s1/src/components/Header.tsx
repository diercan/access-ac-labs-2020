import React from "react";

function Header() {
  return (
    <nav>
      <a href="/">Home</a>
      {" | "}
      <a href="/menu">Menu</a>
      {" | "}
      <a href="/current-order">Current Order</a>
    </nav>
  );
}

export default Header;
