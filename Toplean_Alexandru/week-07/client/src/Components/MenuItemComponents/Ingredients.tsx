import React from "react";

type MenuItemIngredientsProps = {
  ingredients: string;
};

export const MenuItemIngredients = (props: MenuItemIngredientsProps) => {
  return (
    <ul>
      {props.ingredients.split(";").map((ingredient) => (
        <li key={ingredient}>{ingredient}</li>
      ))}
    </ul>
  );
};
