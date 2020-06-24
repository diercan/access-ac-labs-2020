import React from "react";
import { Restaurant } from "../models/restaurant";

type RestaurantProps = {
  restaurant: Restaurant;
}

export function RestaurantCard(props: RestaurantProps) {
  return (
    <>
      <div className="col-sm-6 d-flex" >
        <div className="card text-center p-2 m-1">
          <img
            className="card-img-top "
            src="https://media-cdn.tripadvisor.com/media/photo-s/10/7b/aa/80/entrance-fabrika.jpg"
            alt="Card image cap"
          />
          <div className="card-body ">
            <h5 className="card-title">{props.restaurant.name}</h5>
            <p className="card-text">
              hard coded description
              </p>
            <a href="#" className="btn btn-primary">See Menu</a>
          </div>
          <div className="card-footer text-muted">
            <div className="text-muted">Not visited yet</div>
          </div>
        </div>
      </div>
    </>
  )
}

export default RestaurantCard;