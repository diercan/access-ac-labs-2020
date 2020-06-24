import React, { useState } from "react";
import { Redirect } from "react-router";
import { Form, Row, Container, Col, Button } from "react-bootstrap";

type CreateMenuProps = {
  employeeIsConnected: boolean;
};

export const CreateMenu = (props: CreateMenuProps) => {
  const [isSpecialMenu, setSpecialMenu] = useState(false);

  if (props.employeeIsConnected === false) {
    alert("You must be logged in to create a menu");
    return <Redirect to="/"></Redirect>;
  }
  return (
    <Container>
      <Row>
        <Col>
          <h1 className="centerAlign">Create a new menu!</h1>
        </Col>
      </Row>
      <Row>
        <Col>
          <Form>
            <Form.Group controlId="formGroupEmail">
              <Form.Label>Menu Name</Form.Label>
              <Form.Control type="text" placeholder="Menu name..." />
            </Form.Group>
            <Form.Group controlId="formGroupPassword">
              <Form.Label>Menu Type</Form.Label>
              <Form.Control type="text" placeholder="Menu type..." />
            </Form.Group>
            <Form.Row>
              <Col md={{ span: 2 }}>
                <Form.Check
                  inline
                  label="Special Menu?"
                  aria-label="option 11"
                  onClick={(e: any) => setSpecialMenu(e.target.checked)}
                />
              </Col>
              {isSpecialMenu ? (
                <Col>
                  <Form.Control placeholder="Display Hours" />
                </Col>
              ) : null}
            </Form.Row>
            <Row>
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
