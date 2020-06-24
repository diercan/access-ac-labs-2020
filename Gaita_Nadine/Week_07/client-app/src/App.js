import React from "react";
import { Route, Switch } from "react-router-dom";

import "./App.css";
import Header from "./components/Header/header.component";
import Homepage from "./pages/homepage/homepage.component";

function App() {
  return (
    <div className="App">
      <Header />
      <Switch>
        <Route exact path='/' component={Homepage} />
      </Switch>
    </div>
  );
}

export default App;
