import React, { useState } from "react";
import RestaurantItem from "../RestaurantItem/restaurantItem.component";
import img1 from "./../../assets/img1.jpg";
import img2 from "./../../assets/img2.jpg";
import img3 from "./../../assets/img3.jpg";

const Directory = () => {
  const [restaurants, setRestaurants] = useState([
    {
      id: 1,
      title: "Gratarul cu Staif",
      imgUrl: `${img1}`,
      nota: 4.5,
    },
    {
      id: 2,
      title: "Homemade",
      imgUrl: `${img2}`,
      nota: 5,
    },
    {
      id: 3,
      title: "Berarescu",
      imgUrl: `${img3}`,
      nota: 4.2,
    },
  ]);
  return (
    <div class="container mt-3">
      <div class="row">
        {restaurants.map((restaurant) => (
          <RestaurantItem
            key={restaurant.id}
            title={restaurant.title}
            imgUrl={restaurant.imgUrl}
            nota={restaurant.nota}
          />
        ))}
      </div>
    </div>
  );
};

export default Directory;
