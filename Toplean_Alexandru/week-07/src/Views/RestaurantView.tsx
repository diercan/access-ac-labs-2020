import React from "react";

import { Nav, NavDropdown, Col, Row } from "react-bootstrap";
import { MenuItemComponent } from "../Components/MenuItem";
import { Restaurant } from "../Models/Restaurant";

type RestaurantProps = {
  restaurant: Restaurant;
};

type propString = {
  someVal: string;
};

export class RestaurantView extends React.Component<any, any, any> {
  componentDidMount() {}

  render() {
    const handleSelect = (eventKey: any) => alert(`selected ${eventKey}`);
    var counter = 1;
    const restaurant: Restaurant = this.props.location.state.restaurantt;
    return (
      <section>
        <div className="centerAlign topPadding">
          <h1>{restaurant.name}</h1>
        </div>
        {console.log(restaurant)}
        <Nav variant="tabs" defaultActiveKey="/home" onSelect={handleSelect}>
          {restaurant.menus.map((menu) => (
            <Nav.Item>
              <Nav.Link eventKey={"link-" + counter++}>{menu.name}</Nav.Link>
            </Nav.Item>
          ))}
        </Nav>
        <Row>
          <Col md={4}>
            <MenuItemComponent
              menuItem={{ id: 1, name: "Item1", ingredients: "idk", price: 45 }}
            />
          </Col>
        </Row>
      </section>
    );
  }
}
