import React from "react";
import ReactDOM from "react-dom";

type MenueItem = typeof menuItem;

const menuItem = {
  name: "Spaghete carbonara",
  price: 24,
};

const getMenueItemDetails = (item: MenueItem) => `${item.name} - ${item.price} lei`;

ReactDOM.render(
  <div>
    <span>{getMenueItemDetails(menuItem)}</span>
  </div>,
  document.getElementById("root")
);
