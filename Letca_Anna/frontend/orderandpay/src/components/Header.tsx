import React from "react";
import styled from "styled-components";

function Header() {
  return (
    <div
      className="jumbotron text-white jumbotron-image shadow"
      style={{
        backgroundImage: `url(https://www.uschamber.com/co/uploads/images/millennial.jpg)`,
        backgroundPosition: 'center',
        backgroundSize: 'cover',
        backgroundRepeat: 'no-repeat',
        marginBottom: 0
      }}
    >
      <h1>Your waitress is here.</h1>
      <p>Sit back, relax and enjoy your... meal!</p>
      </div>
  )
}

export default Header;