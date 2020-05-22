import React, { Component } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { MenuItem } from "../Models/MenuItem";

type CheckoutProps = {
  menuItems: {
    name?: string;
    comments?: string;
    quantity?: number;
    price?: number;
  }[];
};

export const Checkout = (props: CheckoutProps) => {
  return (
    <React.Fragment>
      <h2 className="centerAlign topPadding">Checkout </h2>
      <br /> <br />
      <table style={{ width: "100%" }}>
        <tr>
          <td>Menu Item</td>
          <td>Quantity</td>
          <td>Comments</td>
          <td>Price</td>
        </tr>
        {console.log(props.menuItems)}
        {props.menuItems.map((item) => (
          <tr key={item.name}>
            <td>{item.name}</td>
            <td>{item.quantity}</td>
            <td>{item.comments}</td>
            <td>{item.price} Lei</td>
          </tr>
        ))}
      </table>
    </React.Fragment>
  );
};
export default Checkout;
