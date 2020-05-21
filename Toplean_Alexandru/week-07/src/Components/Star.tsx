import starr from "../images/starGlow.png";
import React from "react";

type StarClassProp = {
  classType: string;
};

export const Star = (props: StarClassProp) => {
  return <span className={props.classType}></span>;
};
