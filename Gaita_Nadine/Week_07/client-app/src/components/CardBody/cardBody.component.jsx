import React from "react";
import { Button, Badge } from "react-bootstrap";

const CardBody = ({ nota }) => {
  return (
    <div className="card-body">
      <div className="d-flex justify-content-center mt-3">
        <Button variant="outline-secondary">See Menu</Button>
      </div>
      <div className="d-flex justify-content-center mt-3">
        <h4>
          <Badge variant="light">
            {nota}
            <i className="fas fa-star pl-2"></i>
          </Badge>
        </h4>
      </div>
    </div>
  );
};

export default CardBody;
