import React from "react";
import { Link } from "react-router-dom";
import {
    Carousel
} from "react-bootstrap"

function HomePage() {
    return (
        <Carousel>
        {/*slide 1*/}
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="images/slide0.jpg"
            alt="First slide"
          />
          <Carousel.Caption>
            <h3>Search a restaurant</h3>
            <p>You can search a restaurant or you can find it by your location.</p>
          </Carousel.Caption>
        </Carousel.Item>
        {/*slide 2*/}
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="images/slide1.jpg"
            alt="Third slide"
          />
          <Carousel.Caption>
            <h3>Order food</h3>
            <p>Choose what do you want to eat and order.</p>
          </Carousel.Caption>
        </Carousel.Item>
        {/*slide 3*/}
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="images/slide2.jpg"
            alt="Third slide"
          />
          <Carousel.Caption>
            <h3>Pay food</h3>
            <p>Pay your order with card directly.</p>
          </Carousel.Caption>
        </Carousel.Item>
    </Carousel>
    );
}

export default HomePage;