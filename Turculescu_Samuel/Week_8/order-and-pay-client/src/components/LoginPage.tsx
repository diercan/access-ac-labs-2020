import React from "react";
import { Link } from "react-router-dom";
import {
    Button,
    Form,
    DropdownButton,
    Dropdown, 
    ButtonGroup,
    ButtonToolbar
} from "react-bootstrap"

function LoginPage() {
    return (
        <Form className="text-center">            
            <Form.Group controlId="validationFormik02" className="App-input-form">
                <Form.Label>Username</Form.Label>
                <Form.Control type="text" placeholder="Username" />
            </Form.Group>

            <Form.Group controlId="formBasicPassword" className="App-input-form">
                <Form.Label>Password</Form.Label>
                <Form.Control type="password" placeholder="Password" />
            </Form.Group>
            <Form.Group controlId="formBasicCheckbox">
                <Form.Check type="checkbox" label="Keep me logged in" />
            </Form.Group>                       
           
            <Button variant="primary" as={Link} to="/restaurants">
                Log In
            </Button>
                <p>If you don't have an account yet, click <Link to="/signup">here</Link>.</p>
        </Form>
    );
}

export default LoginPage;