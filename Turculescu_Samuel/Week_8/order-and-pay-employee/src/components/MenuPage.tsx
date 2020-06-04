import React, { useState, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import { MenuItem } from "./../models/menuItem";
import { getMenuItems, createMenuItem } from "./../services/employeeApi";
import { Button, Table } from "react-bootstrap";
import { useRefetch } from "../services/useRefetch";
import { AddMenuItemModal } from "./AddMenuItemModal";

type MenuRouteProps = {
  menuId: string;
};

interface MenuPageProps extends RouteComponentProps<MenuRouteProps> {}

function MenuPage(props: MenuPageProps) {
  const [menuItems, setMenuItems] = useState<MenuItem[]>();
  const [modalShow, setModalShow] = useState(false);
  const [refetch, setRefetch] = useRefetch();
  
  useEffect(() => {
    getMenuItems(props.match.params.menuId).then((response) => {
      if (response) setMenuItems(response.data);
    });
  }, [props.match.params.menuId, refetch]);

  const addNewItem = (item: MenuItem) => {
    createMenuItem(props.match.params.menuId, item).finally(() => {
      setModalShow(false);
      setRefetch();
    });
  };

  return !menuItems ? (
    <div>Loading... </div>
  ) : (
    <>
      <Button style={{ margin: "20px 0px" }} onClick={() => setModalShow(true)}>
        Add new item
      </Button>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Ingredients</th>
            <th>Allergens</th>
            <th>TotalQuantity</th>            
            <th>Price</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {menuItems.map((item, index) => {
            return (
              <tr >
                <td>{index + 1}</td>
                <td>{item.name}</td>
                <td>{item.ingredients}</td>
                <td>{item.allergens}</td>
                <td>{item.totalQuantity}</td>
                <td>{item.price} lei</td>
                <td>
                  <Button>Edit</Button> <Button variant="danger">Delete</Button>
                </td>             
              </tr>
            );
          })}
        </tbody>
      </Table>
      <AddMenuItemModal
        show={modalShow}
        onClose={() => setModalShow(false)}
        onSaveChanges={addNewItem}
      ></AddMenuItemModal>
    </>
  );
}

export default MenuPage;
