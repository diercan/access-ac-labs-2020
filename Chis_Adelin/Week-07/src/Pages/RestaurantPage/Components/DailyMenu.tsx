import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import styled from "styled-components";
import { MenuItem } from "../../../Models/MenuItemModel";
import { Row, Col, ButtonGroup, Button, FormControl } from "react-bootstrap";

type DailyMenuProps = {
  item: MenuItem;
};

const ImageContainer = styled.img`
  width: 100%;
`;

export const DailyMenuComponent = (props: DailyMenuProps) => {
  let formContent = "";
  return (
    <React.Fragment>
      <Row className="mt-5">
        <Col md={6} xs={12}>
          <ImageContainer
            className="p-5"
            src={props.item.image}
            alt={props.item.name}
          ></ImageContainer>
        </Col>
        <Col md={6} xs={12} className="mt-5">
          <h2 className="text-center">Meniul zilei</h2>
          <h4 className="text-center m-4">{props.item.name}</h4>
          <h5>Ingrediente: </h5>
          <p>{props.item.ingredients}</p>
          <h5>Alergeni: </h5>
          <p>{props.item.allergens}</p>
          <h5>Pret:</h5>
          <p>{props.item.price} RON</p>
          <ButtonGroup>
            <FormControl
              placeholder="Cantitate"
              aria-label="Qty"
              aria-describedby="basic-addon1"
            />
            <Button>Adauga</Button>
            <div>{formContent}</div>
          </ButtonGroup>
        </Col>
      </Row>
    </React.Fragment>
  );
};
