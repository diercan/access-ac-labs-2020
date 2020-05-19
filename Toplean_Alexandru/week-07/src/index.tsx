import React from "react";
import ReactDOM from "react-dom";
import "bootstrap/dist/css/bootstrap.min.css";

import { DrawNavbar } from "./Components/Navbar";

const root = document.getElementById("root");
const element = (
  <React.Fragment>
    <DrawNavbar />
  </React.Fragment>
);

ReactDOM.render(element, root);
