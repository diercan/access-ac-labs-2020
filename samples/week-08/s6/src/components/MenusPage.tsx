import React, { useState, useEffect } from "react";
import { MenuList } from "./MenuList";
import { Menu } from "./../models/menu";
import { getMenus } from "./../services/employeeApi";

function MenusPage() {
  const [menus, setMenus] = useState<Menu[]>();
  useEffect(() => {
    getMenus().then((response) => {
      if (response) setMenus(response.data);
    });
  }, []);
  return !menus ? (
    <div>Loading...</div>
  ) : (
    <>
      <h2>Menus</h2>
      <MenuList menus={menus} />
    </>
  );
}

export default MenusPage;
