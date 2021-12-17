import { Container, Heading, SimpleGrid, Text } from "@chakra-ui/react";
import axios from "axios";
import {
  GetServerSideProps,
  InferGetServerSidePropsType,
  NextPage,
} from "next";
import Head from "next/head";
import { Layout } from "../../components";
import ItemCard from "../../components/ItemCard";
import { API_URL } from "../../constants";
import { IItemListing } from "../../model/items.model";

export const getServerSideProps: GetServerSideProps<{
  items: IItemListing[];
  category: string;
}> = async (ctx) => {
  let items: IItemListing[] = [];
  let category = ctx.params?.category as string;

  if (!category || typeof category !== `string`) {
    return {
      props: {
        items: [],
        category: `Not Found`,
      },
    };
  }

  try {
    const res = await axios.get<any>(`${API_URL}/item-listing`, {
      params: { category },
    });

    if (res && res.data) {
      items = res.data;
    }
  } catch (error) {
    console.error(error);
  }

  return {
    props: {
      items,
      category,
    },
  };
};

const ForSalePage: NextPage<
  InferGetServerSidePropsType<typeof getServerSideProps>
> = ({ items, category }) => {
  return (
    <>
      <Head>
        <title>Craigslist Clone | {category}</title>
        <meta name="description" content="Generated by create next app" />
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <Layout>
        <Container mt="16" maxW="container.xl" textAlign="center">
          <Heading as="h2" mb="8" textTransform="uppercase">
            {category} For Sale
          </Heading>

          {(!items || items.length < 1) && (
            <Text fontSize="2xl" fontWeight="medium">
              No Items Found ⚠
            </Text>
          )}

          <SimpleGrid columns={[1, 2, 2, 3]} spacing="8" mt="4">
            {items.map((item) => (
              <ItemCard key={item.id} item={item} />
            ))}
          </SimpleGrid>
        </Container>
      </Layout>
    </>
  );
};

export default ForSalePage;