import { isBrowser } from "@chakra-ui/utils";
import { useState, useEffect, Dispatch, SetStateAction } from "react";

type Response<T> = [T, Dispatch<SetStateAction<T>>];

function usePersistedState<T>(key: string, initialState: T): Response<T> {
  const [isMounted, setMounted] = useState(false);
  const [state, setState] = useState(initialState);

  // ? Reference: https://github.com/vercel/next.js/discussions/17443#discussioncomment-637879
  useEffect(() => {
    setMounted(true);

    if (isBrowser && isMounted) {
      const storageValue = localStorage.getItem(key);

      if (storageValue) {
        try {
          setState(JSON.parse(storageValue));
        } catch (error) {
          console.error(error);
        }
      }
    }
  }, [key, isMounted]);

  useEffect(() => {
    if (isBrowser && isMounted) {
      localStorage.setItem(key, JSON.stringify(state));
    }
  }, [key, state, isMounted]);

  return [state, setState];
}

export default usePersistedState;
