import React from "react";
import { Col } from "react-bootstrap";
import { Link } from "react-router-dom";
import styled from "styled-components";

type RestaurantSelectorProps = {
  slug: string;
  image: string;
  name: string;
};
const Image = styled.img`
  width: auto;
  height: 70px;
  transition: all 0.3s ease-in-out;
  :hover {
    transform: scale(1.2);
  }
`;

export const RestaurantSelectorComponent = (props: RestaurantSelectorProps) => {
    // const img = '../../../assets/img/' + props.image; // props.image = logo-napoleon.png
    // require('../../../assets/img/logo-napoleon.png') is working fine
  return (
    <Col lg={3} md={4} sm={6} className="mt-3 p-3">
      <Link to={props.slug}>
        <Image src={require('../../../assets/img/logo-napoleon.png')} alt = {props.name}/>
      </Link>
    </Col>
  );
};
