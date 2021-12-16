import {
  Button,
  Container,
  FormControl,
  FormHelperText,
  FormLabel,
  Input,
} from "@chakra-ui/react";
import { isBrowser } from "@chakra-ui/utils";
import { DevTool } from "@hookform/devtools";
import { NextPage } from "next";
import Head from "next/head";
import React, { useState } from "react";
import { useForm } from "react-hook-form";
import { Layout } from "../components";
import RegisterLoginForm from "../components/RegisterLoginForm";

type FormValues = {
  username: string;
  password: string;
};

const LoginPage: NextPage = ({}) => {
  const [foo, setFoo] = useState("foo");
  const {
    register,
    handleSubmit,
    setError,
    formState: { errors, isSubmitting, isValid },
  } = useForm<FormValues>({
    mode: `onChange`,
    reValidateMode: `onChange`,
    defaultValues: { username: ``, password: `` },
  });

  const onSubmit = handleSubmit((data) => console.log({ data }));

  return (
    <>
      <Head>
        <title>Craigslist Clone | Login</title>
        <meta name="description" content="Generated by create next app" />
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <Layout>
        <Container mt="8" maxW="480px">
          <RegisterLoginForm action="login" />
        </Container>
      </Layout>
    </>
  );
};

export default LoginPage;
