import React, { useState } from "react";
import { Button, Modal, Col, Row, Container, Form } from "react-bootstrap";
import { NavLink } from "react-router-dom";
import { getClient, createClient } from "../services/clientApi";
import { handleError } from "../services/apiUtils";
import { Restaurant } from "../../Models/Restaurant";
import { Order } from "../../Models/Order";

type LoginModalProps = {
  show: boolean;
  setShow: any;
  setConnectedUser: any;
  setOrder: any;
  order?: Order;
  currentRestaurant?: Restaurant;
};

export const LoginModal = (props: LoginModalProps) => {
  const [connectionError, setConnectionError] = useState<boolean>();
  const [clientIsRegistering, setClientIsRegistering] = useState(false);

  const handleClose = () => props.setShow(false);

  const attemptLogin = () => {
    getClient(username as string, password as string)
      .then((response: any) => {
        if (response.data.reason == null) {
          props.setConnectedUser(response.data.client);
          if (!props.order) {
            props.setOrder({
              clientId: response.data.client.id,
              restaurantId: props.currentRestaurant
                ? props.currentRestaurant.id
                : 0,
              tableNumber: 0,
              totalPrice: 0,
              status: "Uninitialized",
              paymentStatus: "Uninitialized",
              orderItems: [],
            });
          } else {
            props.order.clientId = response.data.client.id;
          }
          handleClose();
        } else setConnectionError(true);
      })
      .catch((error) => {
        alert("Login error");
        console.log(handleError(error));
      });
  };

  const attemptRegister = () => {
    createClient(
      name as string,
      username as string,
      password as string,
      email as string
    )
      .then((response: any) => {
        console.log("Client Successfully created");
        props.setConnectedUser(response.data);
        /* props.setOrder({

        }); */
        handleClose();
      })
      .catch((error: any) => {
        alert("CreateClient error");
        console.log(handleError(error));
      });
  };

  const [name, setName] = useState<string>();
  const [username, setUsername] = useState<string>();
  const [password, setPassword] = useState<string>();
  const [email, setEmail] = useState<string>();

  return (
    <React.Fragment>
      <Modal show={props.show} onHide={handleClose}>
        {!clientIsRegistering ? (
          <React.Fragment>
            <Modal.Header closeButton>
              <Modal.Title>Login</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <Form>
                <Form.Group controlId="formBasicUsername">
                  <Form.Label>Username</Form.Label>
                  {connectionError ? (
                    <Form.Text style={{ color: "red" }}>
                      Wrong credentials or inexistent user!
                    </Form.Text>
                  ) : null}
                  <Form.Control
                    type="text"
                    placeholder="Username..."
                    onChange={(e: any) => setUsername(e.target.value)}
                  />
                </Form.Group>

                <Form.Group controlId="formBasicPassword">
                  <Form.Label>Password</Form.Label>
                  <Form.Control
                    type="password"
                    placeholder="Password..."
                    onChange={(e: any) => setPassword(e.target.value)}
                  />
                </Form.Group>
              </Form>
            </Modal.Body>
          </React.Fragment>
        ) : (
          <React.Fragment>
            <Modal.Header closeButton>
              <Modal.Title>Register</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <Form>
                <Form.Group controlId="createName">
                  <Form.Label>Name</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="Name..."
                    onChange={(e: any) => setName(e.target.value)}
                  />
                </Form.Group>
                <Form.Group controlId="createUsername">
                  <Form.Label>Username</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="Username..."
                    onChange={(e: any) => setUsername(e.target.value)}
                  />
                </Form.Group>

                <Form.Group controlId="createPassword">
                  <Form.Label>Password</Form.Label>
                  <Form.Control
                    type="password"
                    placeholder="Password..."
                    onChange={(e: any) => setPassword(e.target.value)}
                  />
                </Form.Group>
                <Form.Group controlId="createEmail">
                  <Form.Label>Email</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="Email..."
                    onChange={(e: any) => setEmail(e.target.value)}
                  />
                </Form.Group>
              </Form>
            </Modal.Body>
          </React.Fragment>
        )}

        <Modal.Footer>
          <Container>
            <Row>
              <Col className="centerAlign">
                <Button variant="secondary" onClick={handleClose}>
                  Close
                </Button>
              </Col>
              <Col className="centerAlign">
                {!clientIsRegistering ? (
                  <Button variant="primary" onClick={attemptLogin}>
                    Login
                  </Button>
                ) : (
                  <Button variant="primary" onClick={attemptRegister}>
                    Register
                  </Button>
                )}
              </Col>
            </Row>
            <Row className="topPadding centerAlign">
              <Col>
                {!clientIsRegistering ? (
                  <label>
                    New Here?
                    <NavLink
                      to="#"
                      onClick={() =>
                        setClientIsRegistering(!clientIsRegistering)
                      }
                    >
                      Register
                    </NavLink>
                  </label>
                ) : (
                  <label>
                    Already have an account?
                    <NavLink
                      to="#"
                      onClick={() =>
                        setClientIsRegistering(!clientIsRegistering)
                      }
                    >
                      Login
                    </NavLink>
                  </label>
                )}
              </Col>
            </Row>
          </Container>
        </Modal.Footer>
      </Modal>
    </React.Fragment>
  );
};
