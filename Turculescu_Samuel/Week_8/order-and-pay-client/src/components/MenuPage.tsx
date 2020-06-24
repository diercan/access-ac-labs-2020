import React, { useState, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import { MenuItem } from "./../models/menuItem";
import { getMenuItems } from "./../services/clientApi";
import { Button, Table } from "react-bootstrap";
import { useRefetch } from "../services/useRefetch";

type MenuRouteProps = {
  menuId: string;
};

interface MenuPageProps extends RouteComponentProps<MenuRouteProps> {}

function MenuPage(props: MenuPageProps) {
  const [menuItems, setMenuItems] = useState<MenuItem[]>();
  const [refetch, setRefetch] = useRefetch();
  
  useEffect(() => {
    getMenuItems(props.match.params.menuId).then((response) => {
      if (response) setMenuItems(response.data);
    });
  }, [props.match.params.menuId, refetch]);
 

  return !menuItems ? (
    <div>Loading... </div>
  ) : (
    <>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Ingredients</th>
            <th>Allergens</th>
            <th>TotalQuantity</th>            
            <th>Price</th>
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
              </tr>
            );
          })}
        </tbody>
      </Table>
    </>
  );
}

export default MenuPage;
