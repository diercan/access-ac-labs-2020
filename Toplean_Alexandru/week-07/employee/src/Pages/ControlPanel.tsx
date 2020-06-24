import React, { useState, useEffect } from "react";
import { Nav, Row, Col } from "react-bootstrap";
import { getMenus } from "../Components/services/employeeApi";
import { Menu } from "../Models/Menu";
import { handleError } from "../Components/services/apiUtils";
import {
  NavLink,
  Switch,
  Route,
  BrowserRouter as Router,
} from "react-router-dom";
import { ViewMenuItems } from "./ViewMenuItems";

export const ControlPanel = (props: any) => {
  var restaurant = props.match.params.restaurant;
  const [menus, setMenus] = useState<Menu[]>();
  const [selectedMenu, setSelectedMenu] = useState<any>();
  const [mouseOverMenu, setMouseOverMenu] = useState("");
  useEffect(() => {
    getMenus(props.match.params.restaurant).then((response) => {
      if (response) {
        setMenus(response.data);
      }
    }, handleError);
  }, [props.match.params.restaurant]);

  useEffect(() => {}, [selectedMenu]);

  return !menus ? (
    <p>Loading...</p>
  ) : (
    <React.Fragment>
      <Router>
        <Row
          style={{
            marginLeft: 0,
            marginRight: 0,
            height: "93.9vh",
          }}
        >
          <Col md={2} style={{ backgroundColor: "black" }}>
            <Nav defaultActiveKey="/home" className="flex-column">
              <h4 style={{ color: "#189AD3" }}>Menus </h4>
              {menus.map((menu: any) => (
                <NavLink
                  to={`/${restaurant}/controlPanel/${menu.Name}/all`}
                  key={menu.Name}
                  className="noHyperLinks"
                  onMouseOver={(e: any) => {
                    let target = e.target;
                    target.style = "background-color:white;color:black";
                    setMouseOverMenu(target.getAttribute("data-rb-event-key"));
                  }}
                  onMouseOut={(e: any) => {
                    let target = e.target;
                    target.style = "background-color:black;color:white";
                  }}
                  onClick={(e: any) => {
                    setSelectedMenu(e.target);
                  }}
                >
                  {menu.Name} {mouseOverMenu === menu.Name ? <p></p> : <p></p>}
                </NavLink>
              ))}
            </Nav>
          </Col>
          <Col>
            <Switch>
              <Route
                exact
                path="/:restaurant/controlPanel/:menu/all"
                component={ViewMenuItems}
              ></Route>
            </Switch>
          </Col>
        </Row>
      </Router>
    </React.Fragment>
  );
};
