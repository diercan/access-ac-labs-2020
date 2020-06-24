import React, { useEffect, useState } from "react";
import {
  Accordion,
  Card,
  Container,
  Row,
  Col,
  useAccordionToggle,
  Form,
  Button,
} from "react-bootstrap";
import { getMenuItemsById, updateOrder } from "./services/employeeApi";
import { handleError } from "./services/apiUtils";
import { MenuItem } from "../Models/MenuItem";
import { Order } from "../Models/Order";

type OrderItemProps = {
  order: Order;
  id: number;
  tableNumber: number;
  orderItems: any[];
  completed: boolean;
  setRefetch: any;
};

function CustomAcordionHead({ children, eventKey }: any) {
  const decoratedOnClick = useAccordionToggle(eventKey, () =>
    console.log("totally custom!")
  );
  return (
    <Card.Header
      style={{ backgroundColor: "#189AD3" }}
      onClick={decoratedOnClick}
    >
      <h4>{children}</h4>
    </Card.Header>
  );
}

export const OrderItem = (props: OrderItemProps) => {
  const idStr = props.orderItems.map((item) => item.menuItemId).join(";");
  const [menuItems, setMenuItems] = useState<MenuItem[]>();
  const completeOrder = () => {
    let order = props.order;
    order.completed = true;
    updateOrder(order)
      .then((response) => {
        props.setRefetch();
      })
      .catch((error) => {
        alert("error");
        handleError(error);
      });
  };
  useEffect(() => {
    getMenuItemsById(idStr)
      .then((response) => setMenuItems(response.data))
      .catch((error) => {
        alert("GetMenuItemsById Error");
        console.log(handleError(error));
      });
  }, []);
  return menuItems ? (
    <Container className="topPadding">
      <Row>
        <Col>
          <Accordion defaultActiveKey="0">
            <Card>
              <CustomAcordionHead eventKey="asd">
                Table No. {props.tableNumber}
              </CustomAcordionHead>
              <Accordion.Collapse eventKey="asd">
                <Card.Body>
                  <table style={{ width: "100%" }}>
                    <thead style={{ marginBottom: "110px" }}>
                      <tr
                        className="bottomBorder "
                        style={{ color: "black !important" }}
                      >
                        <td>Menu</td>
                        <td>Quantity</td>
                        <td>Comment</td>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td></td>
                      </tr>
                      {props.orderItems.map((orderItem) => (
                        <tr key={`${orderItem.id}_${orderItem.name}` as string}>
                          <td>
                            {
                              menuItems.filter(
                                (menuItem) =>
                                  menuItem.id === orderItem.menuItemId
                              )[0].name
                            }
                          </td>
                          <td>x{orderItem.quantity}</td>
                          <td>{orderItem.comment}</td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                  {props.completed == false ? (
                    <Row className="topPadding">
                      <Col lg={{ offset: 8 }}>
                        <Form>
                          <Form.Group controlId="formBasicCheckbox">
                            <Button onClick={completeOrder}>
                              Mark as Complete
                            </Button>
                          </Form.Group>
                        </Form>
                      </Col>
                    </Row>
                  ) : null}
                </Card.Body>
              </Accordion.Collapse>
            </Card>
          </Accordion>
        </Col>
      </Row>
    </Container>
  ) : (
    <p>Loading</p>
  );
};
