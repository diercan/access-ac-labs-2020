import React, {useState} from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import {MenuItem} from "../Models/MenuItemModel";
import {Button, Card, ButtonGroup, FormControl, Col} from "react-bootstrap";
import {PostMenuItem} from "../Services/OrdersService";
import {IconButton, Snackbar} from "@material-ui/core";
import CloseIcon from "@material-ui/icons/Close";

type MenuItemProps = {
    item: MenuItem;
};

export const MenuItemPreviewComponent = (props: MenuItemProps) => {
    const [value, setValue] = useState(0);
    const [open, setOpen] = useState(false);
    const [message, setMessage] = useState("Item added successfully!");
    const HandleSubmit = () => {
        if (value > 0) PostMenuItem(props.item, value).then((response) => {
            if (response.status != 200)
                setMessage("Something went wrong! Try again !");
            setOpen(true);
        })};

        return (
            <Card style={{width: "18rem"}} className="mx-auto mt-5">
                <Card.Img variant="top" src={props.item.image}/>
                <Card.Body>
                    <Card.Title>{props.item.name}</Card.Title>
                    <Card.Text>
                        <p>{props.item.ingredients}</p>
                        <p>
                            <b>Alergeni:</b> {props.item.allergens}
                        </p>
                        <p>
                            <b>Pret:</b> {props.item.price} RON
                        </p>
                    </Card.Text>
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
                        action={
                            <IconButton size="small" aria-label="close" color="inherit"
                                        onClick={event => setOpen(false)}>
                                <CloseIcon fontSize="small"/>
                            </IconButton>
                        }/>
                </Card.Body>
            </Card>
        );
    };
