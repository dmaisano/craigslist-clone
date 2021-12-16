import { ChakraProvider, extendTheme } from "@chakra-ui/react";
import { mode } from "@chakra-ui/theme-tools";
import type { AppProps } from "next/app";
import { createContext, Dispatch, SetStateAction } from "react";
import { DEFAULT_USER } from "../constants";
import { IUser } from "../model/user.model";
import usePersistedState from "../utils/usePersistedState";

const theme = extendTheme({
  styles: {
    global: (props: any) => ({
      "html, body, #__next": {
        height: `100%`,
        width: `100%`,
      },
      body: {
        fontFamily: "body",
        color: mode("gray.800", "whiteAlpha.900")(props),
        bg: mode("#fefefe", "gray.800")(props),
        lineHeight: "base",
      },
    }),
  },
});

export const AppUserContext = createContext<
  [IUser, Dispatch<SetStateAction<IUser>>]
>([DEFAULT_USER, () => {}]);

function MyApp({ Component, pageProps }: AppProps) {
  const [user, setUser] = usePersistedState(`user`, DEFAULT_USER);

  return (
    <AppUserContext.Provider value={[user, setUser]}>
      <ChakraProvider theme={theme}>
        <Component {...pageProps} />
      </ChakraProvider>
    </AppUserContext.Provider>
  );
}

export default MyApp;
