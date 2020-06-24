import starr from "../images/starGlow.png";
import React from "react";

type StarClassProp = {
  classType: string;
  id?: string;
  onHoverEvent?: any;
};

export const Star = (props: StarClassProp) => {
  return props.id == undefined ? (
    <span className={props.classType}></span>
  ) : (
    <span
      className={props.classType}
      id={props.id}
      onMouseOver={props.onHoverEvent}
    ></span>
  );
};
