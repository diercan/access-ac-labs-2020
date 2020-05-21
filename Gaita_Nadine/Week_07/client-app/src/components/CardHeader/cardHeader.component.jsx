import React from "react";

const CardHeader = ({title, imgUrl}) => {
  return (
    <div>
      <h5 className="card-header">{title}</h5>
      <img className="card-img-top" src={imgUrl} alt="Gratarul cu Staif" />
    </div>
  );
};

export default CardHeader;
