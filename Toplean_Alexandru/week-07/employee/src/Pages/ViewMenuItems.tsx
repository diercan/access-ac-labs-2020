import React, { useState, useEffect } from "react";
import { MenuItem } from "../Models/MenuItem";
import { getMenuItems, getMenu } from "../Components/services/employeeApi";
import { ContentLoading } from "../Components/ContentLoadingComponent";
import { Button, Row, Col } from "react-bootstrap";
import {
  EditMenuItemModal,
  AddMenuItemModal,
} from "../Components/Modals/EditMenuItemModal";
import { Menu } from "../Models/Menu";
import { useRefetch } from "../Components/services/useRefetch";

export const ViewMenuItems = (props: any) => {
  const menu = props.match.params.menu;

  const [menuItems, setMenuItems] = useState<MenuItem[]>();
  const [currentMenu, setCurrentMenu] = useState<Menu>();
  const [menuItemToEdit, setMenuItemToExit] = useState<MenuItem>();
  const [openEdit, setOpenEdit] = useState(false);
  const [openAdd, setOpenAdd] = useState(false);
  const [refetch, setRefetch] = useRefetch();

  useEffect(() => {
    {
      if (menuItemToEdit != undefined) setOpenEdit(true);
    }
  }, [menuItemToEdit]);

  useEffect(() => {
    getMenu(props.match.params.restaurant, props.match.params.menu)
      .then((response) => {
        if (response) {
          setCurrentMenu(response.data);
        }
      })
      .catch((error) => {
        alert("getMenu Error");
        console.log(error);
      });
  }, [props.match.params.menu]);

  useEffect(() => {
    getMenuItems(props.match.params.restaurant, props.match.params.menu).then(
      (response) => {
        if (response) {
          setMenuItems(response.data);
        }
      },
      (error) => {
        alert("An error has occured");
        console.log(error);
      }
    );
  }, [props.match.params.menu, refetch]);

  return (
    <React.Fragment>
      <Row>
        <Col>
          {!menuItems ? (
            <ContentLoading />
          ) : (
            <React.Fragment>
              <Button
                style={{ marginTop: "30px" }}
                onClick={() => setOpenAdd(true)}
              >
                Add a New Menu Item
              </Button>
              <table style={{ marginTop: "30px", width: "100%" }}>
                <tbody>
                  {menuItems.map((menuItem) => (
                    <tr key={menuItem.name} className="tableBorders">
                      <td> {menuItem.name}</td>
                      <td>{menuItem.price} lei</td>
                      <td>{menuItem.ingredients}</td>
                      {menuItem.alergens != null ? (
                        <td>{menuItem.alergens}</td>
                      ) : (
                        <td>No alergens data...</td>
                      )}
                      <td>{menuItem.alergens}</td>

                      {menuItem.image != null ? (
                        <td>
                          <img src={menuItem.image} width="100px" />
                        </td>
                      ) : (
                        <td>No image data...</td>
                      )}
                      <td>
                        <Button
                          variant="success"
                          onClick={() => setMenuItemToExit(menuItem)}
                        >
                          Edit
                        </Button>
                        &ensp;
                        <Button variant="danger">Delete</Button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </React.Fragment>
          )}
        </Col>
      </Row>
      {openEdit ? (
        <EditMenuItemModal
          setOpenEdit={setOpenEdit}
          openEdit={openEdit}
          setMenuItemToEdit={setMenuItemToExit}
          item={menuItemToEdit}
        />
      ) : null}
      {openAdd ? (
        <AddMenuItemModal
          setOpenAdd={setOpenAdd}
          setRefetch={setRefetch}
          openAdd={openAdd}
          restaurant={props.match.params.restaurant}
          menu={currentMenu as Menu}
        />
      ) : null}
    </React.Fragment>
  );
};
