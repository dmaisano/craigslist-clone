import {
  FormControl,
  FormHelperText,
  FormLabel,
  Input,
} from "@chakra-ui/react";
import axios from "axios";
import React from "react";
import { API_URL } from "../constants";
import { User } from "../model/user.model";
import { usePersistedUser } from "../utils/usePersistedUser";

type FormValues = {
  username?: string;
  password?: string;
  confirmPassword?: string;
};

const RegisterLoginForm: React.FC<{
  action: `login` | `register`;
}> = ({ action }) => {
  const [_, setUser] = usePersistedUser();

  const initialValues: FormValues = {
    username: ``,
    password: ``,
    confirmPassword: ``,
  };

  return <form></form>;
};

export default RegisterLoginForm;
