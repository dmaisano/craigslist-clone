import {
  Box,
  Button,
  Container,
  Flex,
  FormControl,
  FormLabel,
  Input,
  Select,
  SimpleGrid,
} from "@chakra-ui/react";
import axios from "axios";
import {
  GetServerSideProps,
  InferGetServerSidePropsType,
  NextPage,
} from "next";
import Head from "next/head";
import React, { useContext, useState } from "react";
import { useForm } from "react-hook-form";
import NumberFormat from "react-number-format";
import { Layout, NextChakraLink } from "../components";
import { AutoResizeTextarea } from "../components/AutoResizeTextArea";
import FormErrorText from "../components/FormErrorText";
import { API_URL } from "../constants";
import { IItemCategory } from "../model/itemCategory.model";
import { ItemCondition } from "../model/items.model";
import { AppUserContext } from "./_app";

export const getServerSideProps: GetServerSideProps<{
  categories: IItemCategory[];
}> = async () => {
  let categories: IItemCategory[] = [];

  try {
    const res = await axios.get<IItemCategory[]>(`${API_URL}/categories`);

    if (res.data && res.data.length > 0) {
      categories = res.data;
    }
  } catch (error) {
    console.error(error);
  }
  return {
    props: {
      categories,
    },
  };
};

type FormValues = {
  title: string;
  condition: number | null;
  fileImages: FileList | null;
  categoryName: string;
  description: string;
};

const testValues: FormValues = {
  title: `Cat (not really for sale)`,
  condition: ItemCondition.Excellent,
  fileImages: null,
  categoryName: `Furniture`,
  description: `I would never sell a cat. This is a test.`,
};

const SellItemPage: NextPage<
  InferGetServerSidePropsType<typeof getServerSideProps>
> = ({ categories }) => {
  const [{ token }] = useContext(AppUserContext);
  const [price, setPrice] = useState<number>(0);
  const [successfullySubmitted, setSubmit] = useState(false);
  const {
    register,
    handleSubmit,
    formState: { errors, isSubmitting, isValid, touchedFields },
  } = useForm<FormValues>({
    mode: `onChange`,
    reValidateMode: `onChange`,
    // defaultValues: {
    //   title: ``,
    //   categoryName: ``,
    //   condition: null,
    //   description: ``,
    //   fileImages: [],
    // },
    defaultValues: testValues,
  });

  const onSubmit = handleSubmit(async (data: FormValues) => {
    try {
      const payload = {
        ...data,
        price,
      };

      const formData = new FormData();
      for (const [key, value] of Object.entries(payload)) {
        if (value instanceof FileList) {
          const images = value as FileList;

          for (let i = 0; i < images.length; i++) {
            const image = images.item(i);

            // skipping images larger than 5mb
            if (image && image?.size > 5242880) {
              continue;
            }

            formData.append(key, image as Blob, image?.name);
          }
        } else {
          if (key !== null && value !== null) {
            formData.append(key, value.toString());
          }
        }
      }

      const res = await axios.post(
        `${API_URL}/item-listing/add-new-item`,
        formData,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        },
      );

      if (res.status === 200) {
        setSubmit(true);
      }
    } catch (error) {
      console.error(error);
    }
  });

  return (
    <>
      <Head>
        <title>Craigslist Clone | Sell Item</title>
        <meta name="description" content="Generated by create next app" />
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <Layout>
        <Container
          mt="8"
          maxW="container.md"
          sx={{
            ".chakra-form-control": {
              mt: 4,
            },
          }}
        >
          <form onSubmit={onSubmit}>
            <FormControl id="title">
              <FormLabel htmlFor="title">Title</FormLabel>
              <Input
                type="text"
                placeholder="Please enter a title..."
                {...register(`title`, {
                  required: true,
                })}
              />
              <FormErrorText error={errors.title} />
            </FormControl>

            <SimpleGrid columns={[1, 1, 3]} spacingX={4}>
              <FormControl id="price" width="full">
                <FormLabel htmlFor="price">Price</FormLabel>
                <NumberFormat
                  customInput={Input}
                  prefix="$ "
                  decimalScale={2}
                  thousandSeparator
                  allowEmptyFormatting
                  allowNegative={false}
                  value={price}
                  onValueChange={({ floatValue }) => {
                    if (typeof floatValue === `number`) {
                      setPrice(floatValue);
                    }
                  }}
                />
              </FormControl>

              <FormControl id="categoryName" width="full">
                <FormLabel htmlFor="categoryName">Category Name</FormLabel>
                <Select
                  placeholder="Select a category"
                  {...register(`categoryName`, {
                    required: true,
                  })}
                >
                  {categories.map(({ name: cName }) => (
                    <option key={cName}>{cName}</option>
                  ))}
                </Select>
                <FormErrorText error={errors.categoryName} />
              </FormControl>

              <FormControl id="condition">
                <FormLabel htmlFor="condition">Condition</FormLabel>
                <Select
                  placeholder="Select a category"
                  {...register(`condition`, {
                    required: true,
                    valueAsNumber: true,
                  })}
                >
                  <option value={ItemCondition.New}>New</option>
                  <option value={ItemCondition.LikeNew}>Like New</option>
                  <option value={ItemCondition.Excellent}>Excellent</option>
                  <option value={ItemCondition.Good}>Good</option>
                  <option value={ItemCondition.Fair}>Fair</option>
                  <option value={ItemCondition.Salvage}>Salvage</option>
                </Select>
                <FormErrorText error={errors.condition} />
              </FormControl>
            </SimpleGrid>

            <FormControl id="description">
              <FormLabel htmlFor="description">Description</FormLabel>
              <AutoResizeTextarea
                placeholder="Please enter a description..."
                minH="250px"
                maxH="600px"
                {...register(`description`, {
                  required: false,
                })}
              />
            </FormControl>

            <FormControl mt="4" id="fileImages">
              <FormLabel htmlFor="fileImages">
                Images. Max size 5mb. JPG | PNG
              </FormLabel>

              <input
                type="file"
                multiple
                accept="image/jpeg,image/png"
                {...register(`fileImages`, {
                  required: true,
                })}
              />
            </FormControl>

            <Flex alignItems="center" mt="6">
              <Button
                disabled={!isValid || isSubmitting || successfullySubmitted}
                colorScheme="blue"
                isLoading={isSubmitting}
                type="submit"
                mr="4"
              >
                {successfullySubmitted ? `Posted` : `Submit`}
              </Button>
              <NextChakraLink
                href={"/"}
                color="blue.500"
                fontWeight="semibold"
                fontSize="1xl"
              >
                Go Home
              </NextChakraLink>
            </Flex>
          </form>
        </Container>
      </Layout>
    </>
  );
};

export default SellItemPage;
