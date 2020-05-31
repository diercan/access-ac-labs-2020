import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import React from "react";
import { DailyMenuComponent } from "./Pages/RestaurantPage/Components/DailyMenu";
import { DailyMenu } from "./Data/DailyMenu";
import RestaurantPageResolver from "./Pages/Resolvers/RestaurantPageResolver";

// TODO: Remove Components from Routes and unused imports
export const RoutesComponent = () => {
  return (
    <Router>
      <Switch>
        <Route path="/" exact>
          <DailyMenuComponent item={DailyMenu} />
        </Route>
        <Route path="/:slug" exact component={RestaurantPageResolver} />
        <Route>
          <DailyMenuComponent item={DailyMenu} />
        </Route>
      </Switch>
    </Router>
  );
};
