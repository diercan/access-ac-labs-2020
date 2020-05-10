import React from "react";
import { useInterval } from "./use-interval";
React.memo
export const useCounter = () => {
  const [counter, setCounter] = React.useState(0);
  const incrementCounter = () => setCounter(counter + 1);
  const { onStart, onStop } = useInterval(incrementCounter, 1000);

  return {
    counter,
    onStart,
    onStop,
  };
};
