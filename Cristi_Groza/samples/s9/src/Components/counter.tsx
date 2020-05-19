import React from "react";
import { useCounter } from "./use-counter";
import { CounterView } from "./counter-view";

export const Counter = () => {
  const { counter, onStart, onStop } = useCounter();
  return (
    <CounterView
      counter={counter}
      onStart={onStart}
      onStop={onStop}
    ></CounterView>
  );
};
