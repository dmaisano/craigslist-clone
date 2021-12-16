import { isBrowser } from "@chakra-ui/utils";
import { Dispatch, SetStateAction, useEffect, useState } from "react";
import { DEFAULT_USER } from "../constants";
import { IUser } from "../model/user.model";

export type PersistedUserResponse = [IUser, Dispatch<SetStateAction<IUser>>];

export const usePersistedUser = (
  initialState: IUser = DEFAULT_USER,
): PersistedUserResponse => {
  const key = `user`;
  const [state, setState] = useState<IUser>(() => {
    if (isBrowser) {
      const storageValue = localStorage.getItem(key);

      if (storageValue) {
        return JSON.parse(storageValue);
      }
    }

    return initialState;
  });

  useEffect(() => {
    console.log(`I RAN`);

    if (isBrowser) {
      console.log(`IS BROWSER`);
      localStorage.setItem(key, JSON.stringify(state));
    }
  }, [key, state]);

  return [state, setState];
};
