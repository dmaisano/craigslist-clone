import type { AppProps } from "next/app";
import { ChakraProvider, extendTheme } from "@chakra-ui/react";
import { mode } from "@chakra-ui/theme-tools";
import { createContext, useContext } from "react";
import { IUser } from "../model/user.model";
import {
  usePersistedUser,
  PersistedUserResponse,
} from "../utils/usePersistedUser";
import { DEFAULT_USER } from "../constants";

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

export const AppUserContext = createContext<PersistedUserResponse>([
  DEFAULT_USER,
  () => {},
]);

function MyApp({ Component, pageProps }: AppProps) {
  const [user, setUser] = usePersistedUser(DEFAULT_USER);

  return (
    <ChakraProvider theme={theme}>
      <AppUserContext.Provider value={[user, setUser]}>
        <Component {...pageProps} />
      </AppUserContext.Provider>
    </ChakraProvider>
  );
}

export default MyApp;
