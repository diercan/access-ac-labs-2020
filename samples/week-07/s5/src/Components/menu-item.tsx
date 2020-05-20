import React from "react";
import { MenuItem } from "./../Models/menu-item";
import styled from "styled-components";

type MenuItemProps = {
  item: MenuItem;
};

const ItemDescription = styled.span`
  color: red;
`;

export const MenuItemComponent = (props: MenuItemProps) => {
  return (
    <div>
      <ItemDescription>
        {props.item.name} - {props.item.price} lei
      </ItemDescription>
    </div>
  );
};
