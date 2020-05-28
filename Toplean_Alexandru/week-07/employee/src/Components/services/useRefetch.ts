import { useState } from "react";

export const useRefetch = (): [number, () => void] => {
  const [key, setKey] = useState(0);
  return [
    key,
    () => {
      setKey((k) => k + 1);
    },
  ];
};
