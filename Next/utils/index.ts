export const allowOnlyNumber = (value: string) => {
  return value.replace(/[^0-9]/g, "");
};

const isValidNumber = (value: string, errorMsg = `Invalid number`) => {
  const matches = value.match(
    /^(?:0\.(?:0[0-9]|[0-9]\d?)|[0-9]\d*(?:\.\d{1,2})?)(?:e[+-]?\d+)?$/,
  );

  if (matches) {
    return matches.length > 0 || errorMsg;
  }

  return errorMsg;
};
