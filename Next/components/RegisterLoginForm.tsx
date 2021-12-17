import {
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

  const password = useWatch({ control, name: `password` });

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
      } else {
        throw new Error();
      }
    } catch (error) {
      alert(`Failed to login`);
    }
  });

  return (
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
              validate: (value) => value.length > 0 || `Required`,
            })}
          />
          {errors.usernameOrEmail && (
            <FormHelperText color="red" fontWeight="semibold">
              {errors.usernameOrEmail.message || `Required`}
            </FormHelperText>
          )}
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
              validate: (value) => value.length > 0 || `Required`,
            })}
          />
          {errors.username && (
            <FormHelperText color="red" fontWeight="semibold">
              {errors.username.message || `Required`}
            </FormHelperText>
          )}
        </FormControl>
      )}
      {action === `register` && (
        <FormControl id="email" mt="4">
          <FormLabel htmlFor="email">Email</FormLabel>
          <Input
            id="email"
            type="text"
            placeholder="Please enter a valid email..."
            {...register(`email`, {
              required: true,
              validate: (value) => value.length > 0 || `Required`,
            })}
          />
          {errors.email && (
            <FormHelperText color="red" fontWeight="semibold">
              {errors.email.message || `Required`}
            </FormHelperText>
          )}
        </FormControl>
      )}
      <FormControl mt="4" id="password">
        <FormLabel htmlFor="password">Password</FormLabel>
        <Input
          id="password"
          type="password"
          placeholder="Please enter a password..."
          {...register(`password`, {
            required: true,
            validate: (value) => value.length > 0 || `Required`,
          })}
        />
        {errors.password && (
          <FormHelperText color="red" fontWeight="semibold">
            {errors.password.message || `Required`}
          </FormHelperText>
        )}
      </FormControl>
      {action === `register` && (
        <FormControl mt="4" id="confirmPassword">
          <FormLabel htmlFor="confirmPassword">Confirm Password</FormLabel>
          <Input
            id="confirmPassword"
            type="password"
            placeholder="Verify password..."
            {...register(`confirmPassword`, {
              required: action === `register`,
              validate: (value) =>
                action === `register` &&
                value &&
                (value.length > 0 || `Required`) &&
                (value === password || `Passwords do not match`),
            })}
          />
          {errors.confirmPassword && (
            <FormHelperText color="red" fontWeight="semibold">
              {errors.confirmPassword.message || `Required`}
            </FormHelperText>
          )}
        </FormControl>
      )}
      <Button
        disabled={!isValid || isSubmitting}
        mt="4"
        colorScheme="blue"
        isLoading={isSubmitting}
        type="submit"
      >
        {action === `login` ? `Sign In` : `Sign Up`}
      </Button>
    </form>
  );
};

export default RegisterLoginForm;
