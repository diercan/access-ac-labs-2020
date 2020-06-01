import React from "react";
import {
  Accordion,
  Card,
  Container,
  Row,
  Col,
  useAccordionToggle,
  Form,
} from "react-bootstrap";

type OrderItemProps = {
  id: number;
  tableNumber: number;
  menuItems: any[];
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
  alert("order");
  return (
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
                    {/* <tbody>
                      {props.menuItems.map((menuItem) => (
                        <tr key={`${menuItem.Id}_${menuItem.name}` as string}>
                          <td>{menuItem.name}</td>
                          <td>x{menuItem.quantity}</td>
                          <td>{menuItem.comment}</td>
                        </tr>
                      ))}
                    </tbody> */}
                  </table>

                  <Row className="topPadding">
                    <Col lg={{ offset: 8 }}>
                      <Form>
                        <Form.Group controlId="formBasicCheckbox">
                          <Form.Check
                            type="checkbox"
                            label="Mark as complete"
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
  );
};
