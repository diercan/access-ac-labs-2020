import React from "react";
import { Redirect } from "react-router";
import { Container, Row, Col, Form, Button } from "react-bootstrap";

type CreateMenuItemProps = {
  employeeIsConnected: boolean;
};

export const CreateMenuItem = (props: CreateMenuItemProps) => {
  if (props.employeeIsConnected == false) {
    alert("You must be logged in to create a menu");
    return <Redirect to="/"></Redirect>;
  }
  return (
    <Container>
      <Row>
        <Col>
          <h1 className="centerAlign">Create a new menu item!</h1>
        </Col>
      </Row>
      <Row>
        <Col>
          <Form>
            <Form.Group controlId="formGroupEmail">
              <Form.Label>Menu Item Name</Form.Label>
              <Form.Control type="text" placeholder="Menu name..." />
            </Form.Group>

            <Form.Group controlId="formGridState">
              <Form.Label>Menu</Form.Label>
              <Form.Control as="select" value="Choose...">
                <option>Choose...</option>
                <option>...</option>
              </Form.Control>
            </Form.Group>

            <Form.Group controlId="exampleForm.ControlTextarea1">
              <Form.Label>Ingredients</Form.Label>
              <Form.Control as="textarea" rows={3} />
            </Form.Group>
            <Form.Group controlId="exampleForm.ControlTextarea1">
              <Form.Label>Alergens</Form.Label>
              <Form.Control as="textarea" rows={3} />
            </Form.Group>
            <Form.Row>
              <Col>
                <Form.Control placeholder="Price" />
              </Col>
              <Col>
                <Form.File id="custom-file" label="Image" custom />
              </Col>
            </Form.Row>
            <Row className="topPadding">
              <Col md={{ span: 2, offset: 9 }}>
                <Button variant="primary" type="submit">
                  Submit
                </Button>
              </Col>
            </Row>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};
