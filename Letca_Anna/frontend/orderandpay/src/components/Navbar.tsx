import React from "react";
import { NavLink } from "react-router-dom";


function Navbar() {
    const activeStyle = { color: "black" };
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <NavLink className="navbar-brand" activeStyle={activeStyle} exact to="/"
            ><img
                    src="https://cdn0.iconfinder.com/data/icons/kitchen-ware-solid-black/32/Chef_Hat-512.png"
                    width="30"
                    height="30"
                    className="d-inline-block align-top"
                /></NavLink>
            <div className="collapse navbar-collapse" id="navbarText">
                <ul className="navbar-nav mr-auto">
                    <li className="nav-item">
                        <NavLink className="nav-link" activeStyle={activeStyle} exact to="/">Restaurants </NavLink>
                    </li>

                </ul>
                <ul className="nav navbar-nav navbar-right">
                    <li className="nav-item">
                        <NavLink className="nav-link" activeStyle={activeStyle} to="/cart">Cart</NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="nav-link" activeStyle={activeStyle} to="/history">History</NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="nav-link" activeStyle={activeStyle} to="/login">Login</NavLink>
                    </li>
                </ul>
            </div>
        </nav>
    )
}

export default Navbar;