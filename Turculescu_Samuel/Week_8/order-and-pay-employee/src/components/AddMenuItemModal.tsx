import { Modal, Button, Form } from "react-bootstrap";
import React, { useState } from "react";
import { MenuItem } from "../models/menuItem";

type AddMenuItemModalProps = {
  show: boolean;
  onClose: () => void;
  onSaveChanges: (item: MenuItem) => void;
};

export const AddMenuItemModal = (props: AddMenuItemModalProps) => {
  const [name, setName] = useState("");
  const [ingredients, setIngredients] = useState("");
  const [allergens, setAllergens] = useState("");
  const [totalQuantity, setTotalQuantity] = useState(1);
  const [price, setPrice] = useState(0);
  const [availability, setAvailability] = useState(1);
  const [menuId, setMenuId] = useState(1);
  return (
    <Modal
      show={props.show}
      onHide={props.onClose}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Add new item
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group>
            <Form.Label>Name</Form.Label>
            <Form.Control
              type="text"
              placeholder="Name"
              value={name}
              onChange={(e) => setName(e.target.value)}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Ingredients</Form.Label>
            <Form.Control
              type="text"
              placeholder="Ingredients"
              value={ingredients}
              onChange={(e) => setIngredients(e.target.value)}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Allergens</Form.Label>
            <Form.Control
              type="text"
              placeholder="Allergens"
              value={allergens}
              onChange={(e) => setAllergens(e.target.value)}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Total Quantity</Form.Label>
            <Form.Control
              type="number"
              placeholder="Total Quantity"
              value={totalQuantity}
              onChange={(e) => setTotalQuantity(parseInt(e.target.value))}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Price</Form.Label>
            <Form.Control
              type="number"
              placeholder="Price"
              value={price}
              onChange={(e) => setPrice(parseInt(e.target.value))}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Availability</Form.Label>
            <Form.Control
              type="number"
              placeholder="Availability"
              value={availability}
              onChange={(e) => setAvailability(parseInt(e.target.value))}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>MenuId</Form.Label>
            <Form.Control
              type="number"
              placeholder="MenuId"
              value={menuId}
              onChange={(e) => setMenuId(parseInt(e.target.value))}
            />
          </Form.Group>          
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={props.onClose}>
          Close
        </Button>
        <Button
          variant="primary"
          onClick={() => props.onSaveChanges({ name, ingredients, allergens, totalQuantity, price, availability, menuId })}
        >
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  );
};
