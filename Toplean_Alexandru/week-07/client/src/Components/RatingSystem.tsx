import React from "react";
import { Star } from "./Star";

type RatingProps = {
  numberOfStars: number;
};

function GenerateRate(number: number) {
  var arr = ["glow", "glow", "glow", "glow", "glow"];
  arr.forEach((element, index) => {
    if (index >= number) arr[index] = "star";
  });

  const ret = arr.map((x) => (
    <Star classType={x} key={x.toString() + Math.random() * 100} />
  ));
  return ret;
}

export const RatingStarSystem = (props: RatingProps) => {
  return <React.Fragment>{GenerateRate(props.numberOfStars)}</React.Fragment>;
};
