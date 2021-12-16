import { isBrowser } from "@chakra-ui/utils";
import { Dispatch, SetStateAction, useEffect, useState } from "react";
import { IsBrowser } from "../constants";
import { User } from "../model/user.model";

type Response = [User, Dispatch<SetStateAction<User>>];

export const usePersistedUser = (
  initialState: User = { username: ``, token: `` },
): Response => {
  const key = `user`;
  const [state, setState] = useState<User>(() => {
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
};
