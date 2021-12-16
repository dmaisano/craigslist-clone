import { Box, Button, Flex, Heading, Text } from "@chakra-ui/react";
import { isBrowser } from "@chakra-ui/utils";
import { useRouter } from "next/router";
import React from "react";
import { User } from "../model/user.model";
import usePersistedState from "../utils/usePersistedState";
import NextChakraLink from "./NextChakraLink";

interface NavbarProps {}

const Navbar: React.FC<NavbarProps> = ({}) => {
  const [{ username, token }] = usePersistedState<User>(`user`, {
    username: ``,
    token: ``,
  });
  const router = useRouter();

  const logout = () => {
    if (!isBrowser) return;

    localStorage.removeItem(`user`);
    router.push(`/`);
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
          {username && token ? (
            <>
              <Text color="gray.200" float="left" mr="4">
                logged in as {`"${username}"`}
              </Text>

              <Button onClick={() => logout}>Logout</Button>
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
