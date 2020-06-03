import React from 'react';
import './App.css';
import { Switch, Route } from 'react-router-dom';
import SelectRestaurantPage from "./pages/SelectRestaurantPage";

function App() {
  return (
      <div className="container">
        {/*<Header/>*/}
        <Switch>
          {/*<Route path="/" exact component={HomePage} />*/}
          <Route path="/select" component={SelectRestaurantPage} />
          {/*<Route path="/menu/:menuId" component={MenuPage} />*/}
          {/*<Route path="/orders" component={OrdersPage} />*/}
          {/*<Route component={NotFoundPage} />*/}
        </Switch>
        {/*<ErrorReporter></ErrorReporter>*/}
      </div>
  );
}

export default App;
