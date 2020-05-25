import React, { useState } from "react";
import "../css/main.css";
import "../css/darkMode.css";
import SmileyFace from "../images/icons8-smiling-50.png";
import SadFace from "../images/icons8-sad-50.png";
import NeutralFace from "../images/icons8-neutral-50.png";

import { Container, Row, Col, Card, Form, Button } from "react-bootstrap";
import { ReviewComponent } from "../Components/ReviewComponent";

type ReviewProps = {};

export const Reviews = () => {
  const reviewOnSubmit = (e: any) => {
    e.preventDefault();
    let user = (document.getElementById("formName") as any).value;
    let stars = (document.getElementById("formStars") as any).value;
    let comments = (document.getElementById("formComment") as any).value;

    addReviews([
      {
        id: 0,
        name: user,
        stars: Number(stars),
        comment: comments,
        date: "now",
      },
      ...reviews,
    ]);
  };

  const [reviews, addReviews] = useState([
    {
      id: 1,
      name: "user",
      stars: 5,
      comment: "someCommeh here",
      date: "now",
    },
    {
      id: 2,
      name: "user",
      stars: 5,
      comment: "someCommeh here",
      date: "now",
    },
    {
      id: 3,
      name: "user",
      stars: 5,
      comment: "someCommeh here",
      date: "now",
    },
    {
      id: 4,
      name: "user",
      stars: 5,
      comment: "someCommeh here",
      date: "now",
    },
    {
      id: 5,
      name: "user",
      stars: 5,
      comment: "someCommeh here",
      date: "now",
    },
  ]);

  return (
    <Container>
      <Row>
        <Col>
          <h1 className="centerAlign topPadding"> User Feedback</h1>
        </Col>
      </Row>
      <Row className="topPadding">
        <Col md={{ span: 6, offset: 3 }}>
          <Card>
            <Card.Header
              style={{
                backgroundColor: "#189AD3",
                textAlign: "center",
                fontWeight: "bold",
                color: "white",
              }}
            >
              How was your experience?
            </Card.Header>
            <Card.Body>
              <Row>
                <Col>
                  <Form onSubmit={reviewOnSubmit}>
                    <Form.Group controlId="formBasicEmail">
                      <Form.Label>Name</Form.Label>
                      <Form.Control
                        id="formName"
                        type="text"
                        placeholder="Enter name"
                      />
                    </Form.Group>
                    <Form.Group>
                      <Form.Label>Rate your experience</Form.Label>
                      <Form.Control
                        id="formStars"
                        type="text"
                        placeholder="Number of stars"
                      />
                    </Form.Group>
                    <Form.Group controlId="exampleForm.ControlTextarea1">
                      <Form.Label>Tell us your experience</Form.Label>
                      <Form.Control id="formComment" as="textarea" rows={3} />
                    </Form.Group>

                    <Button
                      type="submit"
                      style={{ backgroundColor: "#189AD3" }}
                    >
                      Post review
                    </Button>
                  </Form>
                </Col>
              </Row>
            </Card.Body>
          </Card>
        </Col>
      </Row>
      <Row>
        <Col>
          <hr className="blackLine" />
        </Col>
      </Row>
      <Row>
        {reviews.map((review) => (
          <ReviewComponent
            user={review.name}
            comment={review.comment}
            date={review.date}
            stars={review.stars}
          />
        ))}
      </Row>
    </Container>
  );
};
