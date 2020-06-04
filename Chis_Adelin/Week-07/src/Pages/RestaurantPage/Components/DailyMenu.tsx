import React, {useState} from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import styled from "styled-components";
import {MenuItem} from "../../../Models/MenuItemModel";
import {Row, Col, ButtonGroup, Button} from "react-bootstrap";
import {PostMenuItem} from "../../../Services/OrdersService";
import {IconButton, Snackbar} from "@material-ui/core";
import CloseIcon from "@material-ui/icons/Close";

type DailyMenuProps = {
    item: MenuItem;
};

const ImageContainer = styled.img`
  width: 100%;
`;

export const DailyMenuComponent = (props: DailyMenuProps) => {
    const [value, setValue] = useState(0);
    const [open, setOpen] = useState(false);
    const [message, setMessage] = useState("Item added successfully!");
    const HandleSubmit = () => {
        if (value > 0) PostMenuItem(props.item, value).then( (response) => {
                if(response.status != 200)
                    setMessage("Something went wrong! Try again !");
                    setOpen(true);
                })
    };
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
                        <input
                            type="number"
                            className="form-control quantity-box"
                            placeholder="Qty."
                            onChange={(event) => setValue(parseInt(event.target.value))}
                        />
                        <Button onClick={HandleSubmit}>Adauga</Button>
                    </ButtonGroup>
                    <Snackbar
                        open={open}
                        autoHideDuration={3000}
                        message={message}
                        action ={
                            <IconButton size="small" aria-label="close" color="inherit"
                                        onClick={event => setOpen(false)}>
                                <CloseIcon fontSize="small"/>
                            </IconButton>
                        }/>
                </Col>
            </Row>
        </React.Fragment>
    );
};
