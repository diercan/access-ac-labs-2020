import React from "react";
import { NavLink } from "react-router-dom";
import { 
    Card
} from "react-bootstrap";

function Footer() {
    return (
        <Card className="text-center">
      <Card.Header>About</Card.Header>
      <Card.Body>
        <Card.Title>Order & Pay</Card.Title>
        <Card.Text>
            This website is designed to help restaurants and consumers to communicate more efficient. 
            It simplifies your life and now you have more time.
        </Card.Text>
      </Card.Body>
    </Card>
    );
}

export default Footer;