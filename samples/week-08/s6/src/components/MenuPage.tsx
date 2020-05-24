import React, { useState, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import { MenuDetails, MenuItem } from "../models/menu";
import { getMenu, createMenuItem } from "./../services/employeeApi";
import { Button, Table } from "react-bootstrap";
import { AddMenuItemModal } from "./AddMenuItemModal";
import { useRefetch } from "../services/useRefetch";

type MenuRouteProps = {
  menuId: string;
};

interface MenuPageProps extends RouteComponentProps<MenuRouteProps> {}

function MenuPage(props: MenuPageProps) {
  const [menu, setMenu] = useState<MenuDetails>();
  const [modalShow, setModalShow] = useState(false);
  const [refetch, setRefetch] = useRefetch();
  
  useEffect(() => {
    getMenu(props.match.params.menuId).then((response) => {
      if (response) setMenu(response.data);
    });
  }, [props.match.params.menuId, refetch]);

  const addNewItem = (item: MenuItem) => {
    createMenuItem(props.match.params.menuId, item).finally(() => {
      setModalShow(false);
      setRefetch();
    });
  };

  return !menu ? (
    <div>Loading... </div>
  ) : (
    <>
      <h2>{menu.name}</h2>
      <Button style={{ margin: "20px 0px" }} onClick={() => setModalShow(true)}>
        Add new item
      </Button>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Price</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {menu.menuItems.map((item, index) => {
            return (
              <tr key={item.id}>
                <td>{index + 1}</td>
                <td>{item.name}</td>
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
