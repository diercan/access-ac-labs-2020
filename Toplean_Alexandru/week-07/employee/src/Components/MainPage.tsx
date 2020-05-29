import React, { useState } from "react";
import { Switch, Route } from "react-router-dom";

import { CreateRestaurant } from "../Pages/CreateRestaurant";

import "../css/darkMode.css";
import "../css/main.css";
import { DrawNavbar } from "./Navbar";

import { CreateMenuItem } from "../Pages/CreateMenuItem";
import { ViewOrders } from "../Pages/ViewOrders";
import { Login } from "./Login";
import { ControlPanel } from "../Pages/ControlPanel";

export const MainPage = () => {
  const [employeeIsConnected, setEmployeeConnection] = useState(true);

  return (
    <React.Fragment>
      <DrawNavbar
        employeeIsConnected={employeeIsConnected}
        setEmployeeConnection={setEmployeeConnection}
      />

      <Switch>
        <Route exact path="/">
          {employeeIsConnected ? (
            <ViewOrders
              employeeIsConnected={employeeIsConnected}
              restaurant="McDonalds"
            />
          ) : (
            <Login
              employeeIsConnected={employeeIsConnected}
              setEmployeeConnection={setEmployeeConnection}
            />
          )}
        </Route>

        <Route path=":restaurant/controlPanel">
          <CreateMenuItem employeeIsConnected={employeeIsConnected} />
        </Route>

        <Route path="/viewOrders">
          <ViewOrders
            employeeIsConnected={employeeIsConnected}
            restaurant="McDonalds"
          />
        </Route>

        <Route path="/createRestaurant">
          <CreateRestaurant employeeIsConnected={employeeIsConnected} />
        </Route>

        <Route
          path="/:restaurant/controlPanel"
          component={ControlPanel}
        ></Route>

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
