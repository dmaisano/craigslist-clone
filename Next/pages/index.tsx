import type { NextPage } from "next";
import Head from "next/head";
import { Layout } from "../components";

const HomePage: NextPage = () => {
  return (
    <>
      <Head>
        <title>Craigslist Clone</title>
        <meta name="description" content="Generated by create next app" />
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <Layout></Layout>
    </>
  );
};

export default HomePage;
