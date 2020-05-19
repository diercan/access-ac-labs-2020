import React from "react";

export const useCounter = () => {
  const [counter, setCounter] = React.useState(0);
  return {
    counter,
    onClick: () => setCounter(counter + 1),
  };
};
