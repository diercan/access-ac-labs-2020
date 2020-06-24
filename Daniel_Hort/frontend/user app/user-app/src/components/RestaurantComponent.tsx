import {RestaurantModel} from "../models/RestaurantModel";
import React from "react";
import {Link} from "react-router-dom";
import Button from "react-bootstrap/Button";
import ListGroup from "react-bootstrap/ListGroup";

type RestaurantComponentProps = {
    restaurant: RestaurantModel;
};

function RestaurantComponent(props: RestaurantComponentProps) {
    return (
        <ListGroup.Item>
            <div>
                <h6 className="text-secondary">{props.restaurant.name}</h6>
                <p>{props.restaurant.address}</p>
            </div>

            {/*TODO: make functionality and menus page*/}
            <Link className="align-self-end" to={"/"}>
                <Button variant={"primary"}>Choose</Button>
            </Link>
        </ListGroup.Item>
    );
}

export default RestaurantComponent;
