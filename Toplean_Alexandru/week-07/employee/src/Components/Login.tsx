import React from "react";
import { Form, Button } from "react-bootstrap";
type LoginProps = {
  employeeIsConnected: boolean;
  setEmployeeConnection: any;
};

export const Login = (props: LoginProps) => {
  return (
    <Form
      onSubmit={(e: any) => {
        e.preventDefault();
        props.setEmployeeConnection(!props.employeeIsConnected);
      }}
    >
      <Button type="submit">Fake login/logout</Button>
    </Form>
  );
};
