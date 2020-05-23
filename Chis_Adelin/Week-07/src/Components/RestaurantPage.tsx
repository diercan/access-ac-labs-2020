import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import styled from "styled-components";
import { MenuItem } from "../Models/MenuItemModel";
import { Container, Row, Col, ButtonGroup, Button, FormControl } from "react-bootstrap";

type RestaurantPageProps = {
    name: string;
    dailyMenu: MenuItem;
};
const ImageContainer = styled.img`
    width: 100%;
`;
export const RestaurantPageComponent = (props: RestaurantPageProps) =>
{
    return <Container>
            <h1 className="text-center"> {props.name}</h1>
            <Row className="mt-5">
                <Col md={6} xs={12}>                
                    <ImageContainer className="p-5" src={props.dailyMenu.image} alt={props.dailyMenu.name}></ImageContainer>
                </Col>
                <Col md={6} xs={12} className="mt-5">
                    <h2 className="text-center">Meniul zilei</h2>
                    <h4 className="text-center m-4">{props.dailyMenu.name}</h4>
                    <h5>Ingrediente: </h5>
                    <p>{props.dailyMenu.ingredients}</p>
                    <h5>Alergeni: </h5>
                    <p>{props.dailyMenu.allergens}</p>
                    <h5>Pret:</h5>
                    <p>{props.dailyMenu.price} RON</p>
                    <ButtonGroup>
                        <FormControl placeholder="Cantitate" aria-label="Qty" aria-describedby="basic-addon1"/>
                    <Button>Adauga</Button>
                    </ButtonGroup>
                </Col>
            </Row>
        </Container>
};
