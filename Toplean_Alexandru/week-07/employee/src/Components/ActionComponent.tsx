import React from "react";
import ReactDOM from "react-dom";
import { Toast, Alert } from "react-bootstrap";

type SuccessfulActionProps = {};

type FailedActionProps = {};

type ActionProps = {
  num: number;
};
export const ActionComponent = (props: ActionProps) => {
  return props.num === 1 ? (
    <Alert variant="success">Restaurant Successfully created</Alert>
  ) : props.num === 2 ? (
    <Alert variant="danger">Restaurant could not be created</Alert>
  ) : null;
};

export const ActionSuccessful = (props: SuccessfulActionProps) => {
  return (
    <Toast>
      <Toast.Header>
        <Alert variant="success" style={{ textAlign: "center" }}>
          Successfully created the restaurant!
        </Alert>
      </Toast.Header>
    </Toast>
  );
};

export const ActionFailed = (props: FailedActionProps) => {
  return (
    <Toast>
      <Toast.Header>
        <Alert variant="danger" style={{ textAlign: "center" }}>
          Could not create the restaurant!
        </Alert>
      </Toast.Header>
    </Toast>
  );
};
