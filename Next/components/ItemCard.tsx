import { Box, BoxProps, Image, Text } from "@chakra-ui/react";
import React from "react";
import { NextChakraLink } from ".";
import { IItemListing, ItemCondition } from "../model/items.model";
import { formatDateString, splitPascalCase } from "../utils";

const ItemCard: React.FC<
  BoxProps & {
    item: IItemListing;
  }
> = ({
  item: { id: itemId, title, price, condition, datePosted, images },
  ...boxProps
}) => {
  return (
    <Box
      background="gray.100"
      border="1px"
      borderColor="gray.300"
      boxShadow="md"
      borderRadius="xl"
      p="4"
      {...boxProps}
    >
      <Box width="full" mx="auto" mt="2">
        <Image
          alt=""
          src={images[0].url}
          width={[125, 150, 200]}
          height={[125, 150, 200]}
          margin="auto"
        />
      </Box>

      <Box mt="4">
        <NextChakraLink
          href={`/listing/${itemId}`}
          color="blue.500"
          fontWeight="bold"
          fontSize="1xl"
        >
          {title}
        </NextChakraLink>

        <Text fontWeight="semibold" mt="2">
          ${price.toFixed(2)} | {splitPascalCase(ItemCondition[condition])}
        </Text>

        <Text fontWeight="semibold" mt="2">
          {formatDateString(datePosted)}
        </Text>
      </Box>
    </Box>
  );
};

export default ItemCard;
