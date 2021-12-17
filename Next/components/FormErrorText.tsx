import { FormHelperText } from "@chakra-ui/react";
import React from "react";

interface FormerrortextProps {
  error: any;
  errorMessage?: string;
  [key: string]: any;
}

const FormErrorText: React.FC<FormerrortextProps> = ({
  error = null,
  errorMessage = `Required`,
  ...props
}) => {
  if (error === null || error === undefined) return null;

  return (
    <FormHelperText color="red" fontWeight="semibold">
      {error?.message || `Required`}
    </FormHelperText>
  );
};

export default FormErrorText;
