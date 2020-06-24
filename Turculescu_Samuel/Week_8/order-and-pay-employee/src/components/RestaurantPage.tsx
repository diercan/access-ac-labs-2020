import React, { useState, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import { Restaurant } from "./../models/restaurant";
import { getRestaurant } from "./../services/employeeApi";
import { useRefetch } from "../services/useRefetch";
import { 
    Card
} from "react-bootstrap";

type RestaurantRouteProps = {
    restaurantName: string;
  };
  
  interface RestaurantPageProps extends RouteComponentProps<RestaurantRouteProps> {}
  
  function RestaurantPage(props: RestaurantPageProps) {
    const [restaurant, setRestaurant] = useState<Restaurant>();
    const [refetch, setRefetch] = useRefetch();
    
    useEffect(() => {
      getRestaurant(props.match.params.restaurantName).then((response) => {
        if (response) setRestaurant(response.data);
      });
    }, [props.match.params.restaurantName, refetch]);
  
    return !restaurant ? (
      <div>Loading... </div>
    ) : (
      <>
         <Card>
            <Card.Body>
                <Card.Text>
                    <h1 className="text-center font-italic">Welcome to {restaurant.name}!</h1>
                </Card.Text>
            </Card.Body>
            <Card.Img variant="bottom" src="../images/restaurant.jpg"/>
        </Card>
      </>
    );
  }
  
  export default RestaurantPage;