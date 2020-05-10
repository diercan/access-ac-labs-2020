import React from "react";

type CounterViewProps = {
  counter: number;
  onClick: () => void;
};

export const CounterView = (props: CounterViewProps) => {
  return (
    <div>
      <span>{props.counter}</span>
      <button onClick={props.onClick}>Click me!</button>
    </div>
  );
};
