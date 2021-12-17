import moment from "moment";

export const allowOnlyNumber = (value: string) => {
  return value.replace(/[^0-9]/g, "");
};

// ? Reference: https://stackoverflow.com/questions/26188882/split-pascal-case-in-javascript-certain-case/26188910
export const splitPascalCase = (word: string) => {
  var re = /($[a-z])|[A-Z][^A-Z]+/g;
  const match = word.match(re);

  if (match) {
    return match.join(` `);
  }

  return word;
};

export const formatDateString = (dateString: string) => {
  try {
    // const date = Date.parse(dateString);
    const date = moment(dateString);

    return date.format(`MM/DD/YY`);
  } catch (error) {
    return `Invalid Date`;
  }
};
