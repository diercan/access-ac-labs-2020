import React, { Component } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../css/main.css";

class OrderHistory extends Component {
  render() {
    return (
      <React.Fragment>
        <h2 className="centerAlign topPadding">OrderHistory </h2>

        <table className="tableBorders">
          <thead>
            <tr>
              <td>Restaurant</td>
              <td>Menu(s)</td>
              <td>Total Price</td>
            </tr>
          </thead>

          <tbody></tbody>
        </table>
      </React.Fragment>
    );
  }
}
export default OrderHistory;
