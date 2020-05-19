import React from "react";

export const useInterval = (func: () => void, interval: number) => {
  const [start, setStart] = React.useState(false);

  React.useEffect(() => {
    const internalHandle = start && setInterval(func, interval);
    return () => {
      if (internalHandle) clearInterval(internalHandle);
    };
  }, [func, start, interval]);

  return {
    onStart: () => setStart(true),
    onStop: () => setStart(false),
  };
};
