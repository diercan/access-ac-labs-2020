import React from "react";
import styled from "styled-components";
import image from "../../../assets/img/header-gif.gif";

const Header = styled.header`
  height: 700px;
  background-image: url(${image});
  background-position: 50% 100%;
  background-size: cover;
`;
const Text = styled.p`
  color: #e9e9e9;
  margin-top: 150px;
  font-size: 50px;
  font-weight: bold;
  line-height: 150%;
  background: -webkit-linear-gradient(#009fff, #ec2f4b);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
`;
export const HeaderBannerComponent = () => {
  return (
    <Header className="d-flex flex-column justify-content-center align-items-center">
      <Text className="text-center">
        Acum poti comanda in restaurantul tau favorit
        <br /> chiar de aici!
      </Text>
      <a href="#link">
        <button type="button" className="btn-sm btn-dark mt-5">
          Selecteaza restaurantul tau !
        </button>
      </a>
    </Header>
  );
};
