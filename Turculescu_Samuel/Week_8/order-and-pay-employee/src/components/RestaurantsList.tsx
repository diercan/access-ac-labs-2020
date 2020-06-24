import React from "react";
import { Link } from "react-router-dom";
import { Restaurant } from "./../models/restaurant";
import {
  Card,
  Button
} from "react-bootstrap";

type RestaurantsListProps = {
    restaurants: Restaurant[];
  };

export function RestaurantsList(props: RestaurantsListProps) {
    return (
        <div className="restaurantsList">
        {props.restaurants.map((restaurant) => {
            return (
                <Card style={{ width: '18rem' }}>
                    <Card.Img variant="top" src="images/restaurant.jpg"/>
                    <Card.Body>
                        <Card.Title>{restaurant.name}</Card.Title>
                        <Card.Text>{restaurant.address}</Card.Text>
                        <Button variant="primary" as={Link} to={"/restaurant/" + restaurant.name}>Select</Button>
                    </Card.Body>
                </Card>
            );
        })}
        </div>
    );
}