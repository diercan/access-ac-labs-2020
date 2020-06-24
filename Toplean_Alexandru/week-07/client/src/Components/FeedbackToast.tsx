import React, { useState } from "react";
import { Toast, Row, Col, Button, Container } from "react-bootstrap";

type FeedbackToastProps = {
  success: boolean;
  title: string;
  message: string;
  timeStamp?: string;
  show?: boolean;
  setShow: any;
};

export const FeedbackToast = (props: FeedbackToastProps) => {
  return (
    <Container>
      <Row>
        <Col xs={12}>
          <Toast
            onClose={() => props.setShow(false)}
            show={props.show}
            delay={10000}
            autohide
          >
            <Toast.Header
              style={{
                backgroundColor: props.success ? "green" : "red",
                color: "black",
              }}
            >
              <img
                src="holder.js/20x20?text=%20"
                className="rounded mr-2"
                alt=""
              />
              <strong className="mr-auto">{props.title}</strong>
              <small>{props.timeStamp}</small>
            </Toast.Header>
            <Toast.Body>{props.message}</Toast.Body>
          </Toast>
        </Col>
      </Row>
    </Container>
  );
};
