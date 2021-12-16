import { Button, Flex, Heading, Text } from "@chakra-ui/react";
import { isBrowser } from "@chakra-ui/utils";
import { useRouter } from "next/router";
import React, { useContext } from "react";
import { DEFAULT_USER } from "../constants";
import { AppUserContext } from "../pages/_app";
import NextChakraLink from "./NextChakraLink";

const Navbar: React.FC = ({}) => {
  const [user, setUser] = useContext(AppUserContext);
  const router = useRouter();

  const logout = () => {
    if (!isBrowser) return;

    // ? I could have optionally removed the user key from localstorage. What I've done here also works 👍
    setUser(DEFAULT_USER);
    router.replace(`/`);
  };

  return (
    <>
      <Flex
        as="nav"
        zIndex={1}
        position="sticky"
        top={0}
        bg="blue.500"
        p={4}
        px="16"
        align="center"
        justifyContent="space-between"
      >
        <Heading as="h3" color="white" fontWeight="normal">
          <NextChakraLink href="/" _hover={{ textDecoration: `none` }}>
            Craigslist Clone
          </NextChakraLink>
        </Heading>

        <Flex alignItems="center" fontWeight="semibold">
          {user.username && user.token ? (
            <>
              <NextChakraLink mr="4" href={`/manage-items`}>
                <Button>Manage Items</Button>
              </NextChakraLink>
              <NextChakraLink mr="4" href={`/sell-item`}>
                <Button>Post Item For Sale</Button>
              </NextChakraLink>
              <Text color="gray.200" float="left" mr="4">
                logged in as {`"${user.username}"`}
              </Text>

              <Button onClick={() => logout()}>Logout</Button>
            </>
          ) : (
            <>
              <NextChakraLink mr="4" href={`/login`}>
                <Button>Login</Button>
              </NextChakraLink>
              <NextChakraLink href={`/register`}>
                <Button>Register</Button>
              </NextChakraLink>
            </>
          )}
        </Flex>
      </Flex>
    </>
  );
};

export default Navbar;
