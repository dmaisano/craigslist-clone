import {
  Box,
  Button,
  FormControl,
  FormHelperText,
  FormLabel,
  Input,
} from "@chakra-ui/react";
import axios from "axios";
import { useRouter } from "next/router";
import React, { useContext } from "react";
import { useForm, useWatch } from "react-hook-form";
import { API_URL, DEFAULT_USER } from "../constants";
import { IUser } from "../model/user.model";
import { AppUserContext } from "../pages/_app";
import FormErrorText from "./FormErrorText";

type FormValues = {
  username: string;
  usernameOrEmail: string;
  email: string;
  password: string;
  confirmPassword: string;
};

const RegisterLoginForm: React.FC<{
  action: `login` | `register`;
}> = ({ action }) => {
  const [_, setUser] = useContext(AppUserContext);
  const router = useRouter();

  const {
    register,
    control,
    handleSubmit,
    formState: { errors, isSubmitting, isValid, touchedFields },
  } = useForm<FormValues>({
    mode: `onChange`,
    reValidateMode: `onChange`,
    defaultValues: {
      ...DEFAULT_USER,
      usernameOrEmail: ``,
      email: ``,
      confirmPassword: action === `register` ? `` : undefined,
    },
  });

  const password = useWatch({ control }).password;

  const onSubmit = handleSubmit(async (data: FormValues) => {
    try {
      const res = await axios.post<IUser>(
        `${API_URL}/account/${action}`,
        data,
        {
          validateStatus: null,
        },
      );

      if (res.status === 200) {
        setUser(res.data);
        await router.replace(`/`);
      } else if (res.status === 401) {
        alert(`Invalid credentials`);
      } else if (res.status === 403) {
        alert(`User already exists`);
      } else {
        throw new Error();
      }
    } catch (error) {
      alert(`Failed to ${action}`);
    }
  });

  return (
    <Box
      sx={{
        ".chakra-form-control": {
          mt: 4,
        },
      }}
    >
      <form onSubmit={onSubmit}>
        {action === `login` ? (
          <FormControl id="usernameOrEmail">
            <FormLabel htmlFor="usernameOrEmail">Username Or Email</FormLabel>
            <Input
              id="usernameOrEmail"
              type="text"
              placeholder="Please enter your username or email..."
              {...register(`usernameOrEmail`, {
                required: true,
              })}
            />
            <FormErrorText error={errors.usernameOrEmail} />
          </FormControl>
        ) : (
          <FormControl id="username">
            <FormLabel htmlFor="username">Username</FormLabel>
            <Input
              id="username"
              type="text"
              placeholder="Please enter a username..."
              {...register(`username`, {
                required: true,
              })}
            />
            <FormErrorText error={errors.username} />
          </FormControl>
        )}
        {action === `register` && (
          <FormControl id="email">
            <FormLabel htmlFor="email">Email</FormLabel>
            <Input
              id="email"
              type="email"
              placeholder="Please enter a valid email..."
              {...register(`email`, {
                required: true,
              })}
            />
            <FormErrorText error={errors.email} />
          </FormControl>
        )}
        <FormControl id="password">
          <FormLabel htmlFor="password">Password</FormLabel>
          <Input
            id="password"
            type="password"
            placeholder="Please enter a password..."
            {...register(`password`, {
              required: true,
            })}
          />
          <FormErrorText error={errors.password} />
        </FormControl>
        {action === `register` && (
          <FormControl id="confirmPassword">
            <FormLabel htmlFor="confirmPassword">Confirm Password</FormLabel>
            <Input
              id="confirmPassword"
              type="password"
              placeholder="Verify password..."
              {...register(`confirmPassword`, {
                required: action === `register`,
                validate: (value) =>
                  action === `register` &&
                  (value === password || `Passwords do not match`),
              })}
            />
            <FormErrorText error={errors.confirmPassword} />
          </FormControl>
        )}
        <Button
          disabled={!isValid || isSubmitting}
          colorScheme="blue"
          isLoading={isSubmitting}
          type="submit"
          mt="4"
        >
          {action === `login` ? `Sign In` : `Sign Up`}
        </Button>
      </form>
    </Box>
  );
};

export default RegisterLoginForm;
