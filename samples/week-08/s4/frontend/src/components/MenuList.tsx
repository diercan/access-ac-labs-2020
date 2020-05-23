import React from "react";
import { Link } from "react-router-dom";
import { Menu } from "./../models/menu";

type MenuListProps = {
  menus: Menu[];
};

export function MenuList(props: MenuListProps) {
  return (
    <table className="table">
      <thead>
        <tr>
          <th>Name</th>
        </tr>
      </thead>
      <tbody>
        {props.menus.map((menu) => {
          return (
            <tr key={menu.id}>
              <td>
                <Link to={"/menu/" + menu.id}>{menu.name}</Link>
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
}

