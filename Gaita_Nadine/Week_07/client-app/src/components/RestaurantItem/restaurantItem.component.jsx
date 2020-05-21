import React from "react";
import CardHeader from "../CardHeader/cardHeader.component";
import CardBody from "../CardBody/cardBody.component";

const RestaurantItem = ({ title, imgUrl, nota }) => {
  return (
    <div class="col-md-4">
      <div className="card mb-4 box-shadow">
        <CardHeader title={title} imgUrl={imgUrl} />
        <CardBody nota={nota} />
      </div>
    </div>
  );
};

export default RestaurantItem;
