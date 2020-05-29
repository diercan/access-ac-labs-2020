import React, { useState, useEffect } from "react";
import { handleError } from "../Components/services/apiUtils";
import { Redirect } from "react-router";
import { Container, Row, Col, Form, Button } from "react-bootstrap";

import { createRestaurant } from "../Components/services/employeeApi";
import { ActionComponent } from "../Components/ActionComponent";

type CreateRestaurantProps = {
  employeeIsConnected: boolean;
};

export const CreateRestaurant = (props: CreateRestaurantProps) => {
  const [name, setName] = useState("");
  const [image, setImage] = useState("");
  const [postStatus, setPostStatus] = useState(0); // 1- post successfull ; 2 - post failed

  useEffect(() => {
    console.log(image);
  }, [image]);

  if (props.employeeIsConnected === false) {
    alert("You must be logged in to create a restaurant");
    return <Redirect to="/"></Redirect>;
  }

  return (
    <React.Fragment>
      <ActionComponent num={postStatus} />
      <Container>
        <Row>
          <Col>
            <h1 className="centerAlign">Create a new Restaurant!</h1>
          </Col>
        </Row>
        <Row>
          <Col>
            <Form>
              <Form.Group controlId="formGroupEmail">
                <Form.Label>Restaurant Name</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Restaurant name..."
                  onChange={(e: any) => setName(e.target.value)}
                />
              </Form.Group>
              <Form.Group controlId="formGroupPassword">
                <Form.Label>Image(optional)</Form.Label>
                <Form.File
                  type="text"
                  id="file"
                  onChange={(e: any) => {
                    var fileList = (document.getElementById("file") as any)
                      .files;
                    var fileReader = new FileReader();
                    if (fileReader && fileList && fileList.length) {
                      fileReader.readAsDataURL(fileList[0]);
                      fileReader.onload = function () {
                        var imageData = fileReader.result;
                        setImage(imageData as string);
                      };
                    }
                  }}
                />
              </Form.Group>

              <Row>
                <Col md={{ span: 2, offset: 9 }}>
                  <Button
                    variant="primary"
                    onClick={() => {
                      createRestaurant(name, image)
                        .then(() => setPostStatus(1))
                        .catch((error) => {
                          handleError(error);
                          console.log(error);
                          setPostStatus(2);
                        });
                    }}
                  >
                    Submit
                  </Button>
                </Col>
              </Row>
            </Form>
          </Col>
        </Row>
      </Container>
    </React.Fragment>
  );
};
