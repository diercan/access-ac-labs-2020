import React from "react";
import { Link } from "react-router-dom";
import {
    Button,
    Form,
    Col
} from "react-bootstrap"

function SignupPage() {
    return (
        <Form className="text-center">
            <Form.Group controlId="validationFormik01" className="App-input-form">
                <Form.Label>First name</Form.Label>
                <Form.Control type="text" placeholder="Enter your first name" />
            </Form.Group>

            <Form.Group controlId="validationFormik02" className="App-input-form">
                <Form.Label>Last name</Form.Label>
                <Form.Control type="text" placeholder="Enter your last name" />
            </Form.Group>
        
            <Form.Group controlId="exampleForm.SelectCustom" className="App-input-form">
                <Form.Label>Type of user select</Form.Label>
                <Form.Control as="select" custom>
                <option>Client</option>
                <option>Employee</option>
                </Form.Control>
            </Form.Group>

            <Form.Group controlId="validationFormik03" className="App-input-form">
                <Form.Label>Restaurant</Form.Label>
                <Form.Control type="text" placeholder="Enter restaurant's name" />
            </Form.Group>
            
            <Form.Group controlId="formBasicEmail" className="App-input-form">
                <Form.Label className="App-input-form">Email address</Form.Label>
                <Form.Control type="email" placeholder="Enter email" />
                <Form.Text className="text-muted">
                We'll never share your email with anyone else.
                </Form.Text>
            </Form.Group>

            <Form.Group controlId="formBasicPassword" className="App-input-form">
                <Form.Label>Password</Form.Label>
                <Form.Control type="password" placeholder="Password" />
            </Form.Group>
            
            <Form.Group controlId="validationFormik03" className="App-input-form">
                <Form.Label>Card Number</Form.Label>
                <Form.Control type="text" placeholder="XXXX - XXXX - XXXX - XXXX" />
            </Form.Group>

            <Button variant="success" type="submit">
                Sign Up
            </Button>
        </Form>
    );
}

export default SignupPage;