import React, { useState, useEffect } from "react";
// eslint-disable-next-line
import { Row, Col, Toast, Button, Alert } from "react-bootstrap";
import { axiosEmployee } from "./../services/axiosEmployee";

export const ErrorReporter = () => {
  const [show, setShow] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  useEffect(() => {
    const interceptor = axiosEmployee.interceptors.response.use(
      function (response) {
        // Any status code that lie within the range of 2xx cause this function to trigger
        // Do something with response data
        return response;
      },
      function (error) {
        // Any status codes that falls outside the range of 2xx cause this function to trigger
        // Do something with response error
        const message = error.message
          ? error.message
          : "Something went wrong, please try again.";
        setErrorMessage(message);
        setShow(true);
        return Promise.reject(error);
      }
    );

    return () => {
      axiosEmployee.interceptors.response.eject(interceptor);
    };
  }, []);

  return (
    <Row style={{ position: "absolute", right: "20px", bottom: "20px" }}>
      <Col xs={12}>
        <Toast onClose={() => setShow(false)} show={show}>
          <Toast.Header>
            <strong className="mr-auto">Error</strong>
          </Toast.Header>
          <Toast.Body>
            <Alert variant="danger"> {errorMessage} </Alert>
          </Toast.Body>
        </Toast>
      </Col>
      {/* // eslint-disable-next-line */}
      {/* <Col xs={6}> */}
      {/* <Button onClick={() => setShow(true)}>Show Toast</Button> */}
      {/* </Col> */}
    </Row>
  );
};
