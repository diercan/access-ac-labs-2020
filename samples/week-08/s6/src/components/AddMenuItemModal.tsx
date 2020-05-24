import { Modal, Button, Form } from "react-bootstrap";
import React, { useState } from "react";
import { MenuItem } from "../models/menu";

type AddMenuItemModalProps = {
  show: boolean;
  onClose: () => void;
  onSaveChanges: (item: MenuItem) => void;
};

export const AddMenuItemModal = (props: AddMenuItemModalProps) => {
  const [name, setName] = useState("");
  const [price, setPrice] = useState(0);
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
            <Form.Label>Price</Form.Label>
            <Form.Control
              type="number"
              placeholder="Price"
              value={price}
              onChange={(e) => setPrice(parseInt(e.target.value))}
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
          onClick={() => props.onSaveChanges({ name, price })}
        >
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  );
};
