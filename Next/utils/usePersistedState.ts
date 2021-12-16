import { isBrowser } from "@chakra-ui/utils";
import { useState, useEffect, Dispatch, SetStateAction } from "react";
import { IsBrowser } from "../constants";

type Response<T> = [T, Dispatch<SetStateAction<T>>];

function usePersistedState<T>(key: string, initialState: T): Response<T> {
  const [state, setState] = useState(() => {
    if (isBrowser) {
      const storageValue = localStorage.getItem(key);

      if (storageValue) {
        return JSON.parse(storageValue);
      }
    }

    return initialState;
  });

  useEffect(() => {
    if (IsBrowser) {
      localStorage.setItem(key, JSON.stringify(state));
    }
  }, [key, state]);

  return [state, setState];
}

export default usePersistedState;
