import React from "react";
import { useCounter } from "./use-counter";
import { CounterView } from "./counter-view";

export const Counter = () => {
  const { counter, onClick } = useCounter();
  return <CounterView counter={counter} onClick={onClick}></CounterView>;
};
