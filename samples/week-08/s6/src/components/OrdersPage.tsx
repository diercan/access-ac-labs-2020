import React from "react";
import {axiosClient} from './../services/axiosClient';
import { Button } from "react-bootstrap";

function OrdersPage() {
  return (
    <>
      <h2>Active orders</h2>
      <p>TODO: list active orders</p>
      <Button onClick={()=>axiosClient.get("invalid-path")}>Generate error</Button>
    </>
  );
}

export default OrdersPage;
