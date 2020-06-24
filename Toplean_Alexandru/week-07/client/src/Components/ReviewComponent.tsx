import React from "react";
import { Col, Row, Card } from "react-bootstrap";
import { RatingStarSystem } from "./RatingSystem";

type ReviewComponentProps = {
  user: String;
  date: string;
  comment: string;
  stars: number;
};

export const ReviewComponent = (props: ReviewComponentProps) => {
  return (
    <Col className="topPadding" md={4}>
      <Card>
        <Card.Body>
          <Row>
            <Col>
              {props.user}
              <br />
              <p style={{ fontSize: "50%" }}>{props.date}</p>
            </Col>
            <Col>
              <RatingStarSystem numberOfStars={props.stars} />
            </Col>
          </Row>
          <Row>
            <Col style={{ textAlign: "justify" }}>{props.comment}</Col>
          </Row>
        </Card.Body>
      </Card>
    </Col>
  );
};
