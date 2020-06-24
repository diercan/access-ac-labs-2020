import React, { useState, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import { MenuList } from "./MenuList";
import { Menu } from "./../models/menu";
import { MenuItem } from "./../models/menuItem";
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
        <MenuList menus={menus} />
      </>
    );
  }

export default MenusPage;
