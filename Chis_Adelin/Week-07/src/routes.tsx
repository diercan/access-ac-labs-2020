import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import React from "react";
import RestaurantPageResolver from "./Pages/Resolvers/RestaurantPageResolver";
import { LandingPageComponent } from "./Pages/LandingPage/LandingPage";

// TODO: Remove Components from Routes and unused imports
export const RoutesComponent = () => {
  return (
    <Router>
      <Switch>
        <Route path="/" exact>
          <LandingPageComponent />
        </Route>
        <Route path="/:slug" exact component={RestaurantPageResolver} />
        <Route>
          <LandingPageComponent />
        </Route>
      </Switch>
    </Router>
  );
};
