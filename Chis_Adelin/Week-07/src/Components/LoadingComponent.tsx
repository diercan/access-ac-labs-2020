import React from "react";
import loading_gif from "../assets/img/loading-gif.gif";
import { Container } from "react-bootstrap";

export const LoadingComponent = () =>
{
    return (
    <Container className="d-flex flex-column align-items-center" >
        <img src={loading_gif} alt="Loading..." height="100%"/>
    </Container>
    );
}