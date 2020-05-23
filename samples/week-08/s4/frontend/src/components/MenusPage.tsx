import React, { useState, useEffect } from "react";
import { MenuList } from "./MenuList";
import { Menu } from "./../models/menu";
import axios from "axios";

function MenusPage() {
  const [menus, setMenus] = useState<Menu[]>();
  useEffect(() => {
    axios
      .get(`http://localhost:5000/api/employee/restaurants/1/menus/`)
      .then((response) => {
        setMenus(response.data);
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
