import React from "react";
import { MenuList } from "./MenuList";
import { menus } from "./../models/mockData";

function MenusPage() {
  return (
    <>
      <h2>Menus</h2>
      <MenuList menus={menus} />
    </>
  );
}

export default MenusPage;
