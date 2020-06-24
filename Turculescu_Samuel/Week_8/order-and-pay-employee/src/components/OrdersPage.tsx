import React, { useState, useEffect } from "react";
import { OrdersList } from "./OrdersList";
import { Order } from "./../models/order";
import { getOrders } from "./../services/employeeApi";

function OrdersPage() {
    const [orders, setOrders] = useState<Order[]>();    
    useEffect(() => {
      getOrders().then((response) => {
        if (response) setOrders(response.data);
      });
    }, []);
    return !orders ? (
      <div>Loading...</div>
    ) : (
      <> 
        <OrdersList orders={orders} />
      </>
    );
  }

  export default OrdersPage;