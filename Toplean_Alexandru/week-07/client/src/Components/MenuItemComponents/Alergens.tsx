import React from "react";

type MenuItemAlergensProps = {
  alergens: string;
};

export const MenuItemAlergens = (props: MenuItemAlergensProps) => {
  return (
    <ul>
      {props.alergens.split(";").map((alergen) => (
        <li key={alergen}>{alergen}</li>
      ))}
    </ul>
  );
};
