import React, { useEffect, useState } from "react";
import {
  Accordion,
  Card,
  Container,
  Row,
  Col,
  useAccordionToggle,
  Form,
} from "react-bootstrap";
import {
  getMenuItemById,
  getMenuItems,
  getMenuItemsById,
} from "./services/employeeApi";
import { handleError } from "./services/apiUtils";
import { MenuItem } from "../Models/MenuItem";

type OrderItemProps = {
  id: number;
  tableNumber: number;
  orderItems: any[];
  completed: boolean;
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

  useEffect(() => {
    getMenuItemsById(idStr)
      .then((response) => setMenuItems(response.data))
      .catch((error) => {
        alert("GetMenuItemsById Error");
        console.log(handleError(error));
      });
  });
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
                        <tr key={`${orderItem.Id}_${orderItem.name}` as string}>
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

                  <Row className="topPadding">
                    <Col lg={{ offset: 8 }}>
                      <Form>
                        <Form.Group controlId="formBasicCheckbox">
                          <Form.Check
                            type="checkbox"
                            label="Mark as complete!"
                          />
                        </Form.Group>
                      </Form>
                    </Col>
                  </Row>
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
