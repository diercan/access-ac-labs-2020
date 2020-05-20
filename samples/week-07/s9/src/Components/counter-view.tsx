import React from "react";

type CounterViewProps = {
  counter: number;
  onStart: () => void;
  onStop: () => void;
};

export const CounterView = (props: CounterViewProps) => {
  return (
    <div>
      <span>{props.counter}</span>
      <button onClick={props.onStart}>Start</button>
      <button onClick={props.onStop}>Stop</button>
    </div>
  );
};
