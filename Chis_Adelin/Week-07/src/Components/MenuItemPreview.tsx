import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import styled from "styled-components";
import { MenuItem } from "../Models/MenuItemModel";
import { Button, Card, ButtonGroup, FormControl } from "react-bootstrap";

type MenuItemProps = {
    item: MenuItem,
};
export const MenuItemPreviewComponent = (props: MenuItemProps) => {
    return (
        <Card style={{ width: '18rem' }} className="mx-auto mt-5">
            <Card.Img variant="top" src={props.item.image} />
            <Card.Body>
                <Card.Title>{props.item.name}</Card.Title>
                <Card.Text>
                    <p>{props.item.ingredients}</p>
                    <p><b>Alergeni:</b> {props.item.allergens}</p>
                    <p><b>Pret:</b> {props.item.price} RON</p>
                </Card.Text>
                <ButtonGroup>
                    <FormControl placeholder="Cantitate" aria-label="Qty" aria-describedby="basic-addon1" />
                    <Button>Adauga</Button>
                </ButtonGroup>
            </Card.Body>
        </Card>)
}