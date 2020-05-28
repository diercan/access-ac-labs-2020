import React, { useState, useEffect } from "react";
import { Button, Modal, Form } from "react-bootstrap";
import { MenuItem } from "../../Models/MenuItem";
import { updateMenuItem, createMenuItem } from "../services/employeeApi";
import { Menu } from "../../Models/Menu";
import { handleError } from "../services/apiUtils";

type EditMenuItemModal = {
  setOpenEdit: any;
  setMenuItemToEdit: any;
  openEdit: boolean;
  item?: MenuItem;
};

type AddMenuItemProps = {
  setOpenAdd: any;
  openAdd: boolean;
  setRefetch: any;
  restaurant: string;
  menu: Menu;
};

export const EditMenuItemModal = (props: EditMenuItemModal) => {
  var menuItem = props.item as MenuItem;

  const [image, setImage] = useState<string>();

  const [name, setName] = useState<string>(menuItem.name);
  const [menuId, setMenuId] = useState<number>(menuItem.menuID as number);
  const [ingredients, setIngredients] = useState<string>(menuItem.ingredients);
  const [alergens, setAlergens] = useState<string>(menuItem.alergens as string);
  const [price, setPrice] = useState<number>(menuItem.price);

  useEffect(() => {
    console.log(image);
  }, [image]);

  function overrideMenuItem() {
    let item = menuItem;
    if (name != undefined) item.name = name as string;
    if (ingredients != undefined) item.ingredients = ingredients as string;
    if (alergens != undefined) item.alergens = alergens as string;
    if (price != undefined) item.price = price as number;
    if (image != undefined)
      if ((image as string).length > 3) item.image = image as string;

    updateMenuItem(item);
  }

  return (
    <React.Fragment>
      <Modal
        show={props.openEdit}
        onHide={() => {
          props.setOpenEdit(false);
          props.setMenuItemToEdit(null);
        }}
      >
        <Modal.Header closeButton>
          <Modal.Title>Edit Menu Item</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="formBasicEmail">
              <Form.Label>Menu Item Name</Form.Label>
              <Form.Control
                type="text"
                value={name}
                onChange={(e: any) => {
                  setName(e.target.value);
                }}
                placeholder="Enter email"
              />
            </Form.Group>
            <Form.Group controlId="exampleForm.SelectCustom">
              <Form.Label>Menu</Form.Label>
              <Form.Control as="select" custom>
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
              </Form.Control>
            </Form.Group>

            <Form.Group controlId="exampleForm.ControlTextarea1">
              <Form.Label>Ingredients</Form.Label>
              <Form.Control
                as="textarea"
                value={ingredients}
                onChange={(e: any) => setIngredients(e.target.value)}
                rows={3}
              />
            </Form.Group>

            <Form.Group controlId="exampleForm.ControlTextarea1">
              <Form.Label>Alergens</Form.Label>
              {menuItem.alergens != null ? (
                <Form.Control
                  as="textarea"
                  value={alergens}
                  onChange={(e: any) => setAlergens(e.target.value)}
                  rows={3}
                />
              ) : (
                <Form.Control
                  as="textarea"
                  onChange={(e: any) => setAlergens(e.target.value)}
                  rows={3}
                />
              )}
            </Form.Group>

            <Form.Group controlId="formBasicPassword">
              <Form.Label>Price</Form.Label>
              <Form.Control
                type="text"
                value={price}
                onChange={(e: any) => setPrice(e.target.value)}
                placeholder="Price"
              />
            </Form.Group>
            <Form.Group>
              <Form.File
                id="custom-file"
                label="Add a picture"
                custom
                onChange={(e: any) => {
                  var fileList = (document.getElementById("custom-file") as any)
                    .files;
                  var fileReader = new FileReader();
                  if (fileReader && fileList && fileList.length) {
                    fileReader.readAsDataURL(fileList[0]);
                    fileReader.onload = function () {
                      var imageData = fileReader.result;
                      setImage(imageData as string);
                    };
                  }
                }}
              />
              {menuItem.image != null ? (
                <React.Fragment>
                  <hr />
                  <div className="centerAlign">
                    <h2 className="centerAlign">Image Preview</h2>
                    <img src={menuItem.image} width="300px" />
                  </div>
                </React.Fragment>
              ) : null}
            </Form.Group>
            <Form.Group controlId="formBasicCheckbox">
              <Form.Check type="checkbox" label="Check me out" />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={() => {
              props.setOpenEdit(false);
              props.setMenuItemToEdit(null);
            }}
          >
            Close
          </Button>
          <Button
            variant="primary"
            onClick={() => {
              props.setOpenEdit(false);
              props.setMenuItemToEdit(null);
              overrideMenuItem();
            }}
          >
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </React.Fragment>
  );
};

export const AddMenuItemModal = (props: AddMenuItemProps) => {
  const [image, setImage] = useState<string>();
  const [name, setName] = useState<string>();
  const [menuId, setMenuId] = useState<number>();
  const [ingredients, setIngredients] = useState<string>();
  const [alergens, setAlergens] = useState<string>();
  const [price, setPrice] = useState<number>();
  useEffect(() => {
    console.log(image);
  }, [image]);
  useEffect(() => {});

  return (
    <React.Fragment>
      <Modal
        show={props.openAdd}
        onHide={() => {
          props.setOpenAdd(false);
          //props.setMenuItemToEdit(null);
        }}
      >
        <Modal.Header closeButton>
          <Modal.Title>Edit Menu Item</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="formBasicEmail">
              <Form.Label>Menu Item Name</Form.Label>
              <Form.Control
                type="text"
                onChange={(e: any) => {
                  setName(e.target.value);
                }}
                placeholder="Enter Item Name"
              />
            </Form.Group>
            <Form.Group controlId="exampleForm.SelectCustom">
              <Form.Label>Menu</Form.Label>
              <Form.Control as="select" custom>
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
              </Form.Control>
            </Form.Group>

            <Form.Group controlId="exampleForm.ControlTextarea1">
              <Form.Label>Ingredients</Form.Label>
              <Form.Control
                as="textarea"
                onChange={(e: any) => setIngredients(e.target.value)}
                rows={3}
              />
            </Form.Group>

            <Form.Group controlId="exampleForm.ControlTextarea1">
              <Form.Label>Alergens</Form.Label>

              <Form.Control
                as="textarea"
                onChange={(e: any) => setAlergens(e.target.value)}
                rows={3}
              />
            </Form.Group>

            <Form.Group controlId="formBasicPassword">
              <Form.Label>Price</Form.Label>
              <Form.Control
                type="text"
                onChange={(e: any) => setPrice(e.target.value)}
                placeholder="Price"
              />
            </Form.Group>
            <Form.Group>
              <Form.File
                id="custom-file"
                label="Add a picture"
                custom
                onChange={(e: any) => {
                  var fileList = (document.getElementById("custom-file") as any)
                    .files;
                  var fileReader = new FileReader();
                  if (fileReader && fileList && fileList.length) {
                    fileReader.readAsDataURL(fileList[0]);
                    fileReader.onload = function () {
                      var imageData = fileReader.result;
                      setImage(imageData as string);
                    };
                  }
                }}
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={() => {
              props.setOpenAdd(false);
              //props.setMenuItemToEdit(null);
            }}
          >
            Close
          </Button>
          <Button
            variant="primary"
            onClick={() => {
              props.setOpenAdd(false);
              createMenuItem(props.restaurant, props.menu.name, {
                name: name as string,
                ingredients: ingredients as string,
                price: Number(price as number),
                alergens: alergens as string,
                image: image as string,
                menuID: props.menu.id as number,
              })
                .then((response) => props.setRefetch())
                .catch((error) => {
                  handleError(error);
                  alert("createmenuitem");
                });
            }}
          >
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </React.Fragment>
  );
};
