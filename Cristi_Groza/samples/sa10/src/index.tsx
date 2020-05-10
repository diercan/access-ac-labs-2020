import React from "react";
import ReactDOM from "react-dom";
import { Menu } from "./Components/menu";
import { paste } from "./Models/menu-item";

ReactDOM.render(<Menu items={paste} />, document.getElementById("root"));
