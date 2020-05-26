import React from "react";
import { Link } from "react-router-dom";

function HomePage() {
  return (
    <div className="jumbotron">
      <h1>Welcome to you favorite restaurant!</h1>
      <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
      <Link to="menus" className="btn btn-primary">
        Menu
      </Link>
    </div>
  );
}

export default HomePage;
