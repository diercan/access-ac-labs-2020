import React, { useState } from "react";
import { Switch, Route } from "react-router-dom";

import restaurantPic from "../images/caruso.jpg";
import mcChicken from "../images/mcChicken.jpg";
import "../css/darkMode.css";
import "../css/main.css";
import { DrawNavbar } from "./Navbar";
import { Button, Form } from "react-bootstrap";
import { CreateMenu } from "../Pages/CreateMenu";
import { CreateMenuItem } from "../Pages/CreateMenuItem";
import { ViewOrders } from "../Pages/ViewOrders";
import { Login } from "./Login";

export const MainPage = () => {
  const [employeeIsConnected, setEmployeeConnection] = useState(false);

  return (
    <React.Fragment>
      <DrawNavbar
        employeeIsConnected={employeeIsConnected}
        setEmployeeConnection={setEmployeeConnection}
      />

      <Switch>
        <Route exact path="/">
          {employeeIsConnected ? (
            <ViewOrders employeeIsConnected={employeeIsConnected} />
          ) : (
            <Login
              employeeIsConnected={employeeIsConnected}
              setEmployeeConnection={setEmployeeConnection}
            />
          )}
        </Route>

        <Route exact path="/createMenu">
          <CreateMenu employeeIsConnected={employeeIsConnected} />
        </Route>

        <Route path="/createMenuItem">
          <CreateMenuItem employeeIsConnected={employeeIsConnected} />
        </Route>

        <Route path="/viewOrders">
          <ViewOrders employeeIsConnected={employeeIsConnected} />
        </Route>
        <Route path="/login">
          <Login
            employeeIsConnected={employeeIsConnected}
            setEmployeeConnection={setEmployeeConnection}
          />
        </Route>
      </Switch>
    </React.Fragment>
  );
};
