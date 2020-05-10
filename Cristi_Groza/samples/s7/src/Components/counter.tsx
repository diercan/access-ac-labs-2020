import React from "react";

export const Counter = () => {
  const [counter, setCounter] = React.useState(0);
  return (
    <div>
      <span>{counter}</span>
      <button onClick={() => setCounter(counter + 1)}>Click Me!</button>
    </div>
  );
};
