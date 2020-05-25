import React from "react";
import { Redirect } from "react-router";
import { OrderItem } from "../Components/OrderItems";
import { Container, Row, Col, Pagination } from "react-bootstrap";

type ViewOrdersProps = {
  employeeIsConnected: boolean;
};

const orders = [
  {
    id: 1,
    tableNumber: 4,
    menuItems: [
      {
        name: "Pizza Pepperoni",
        quantity: 2,
        comment: "Doresc cu ulei de masline",
      },
      {
        name: "Clatite cu Finetti",
        quantity: 1,
        comment: "Si banane",
      },
      {
        name: "Inghetata din Ciocolata Belgiana",
        quantity: 1,
        comment: "-",
      },
    ],
    completed: false,
  },
  {
    id: 2,
    tableNumber: 7,
    menuItems: [
      {
        name: "Pizza Pepperoni",
        quantity: 2,
        comment: "Doresc cu ulei de masline",
      },
      {
        name: "Clatite cu Finetti",
        quantity: 1,
        comment: "Si banane",
      },
      {
        name: "Inghetata din Ciocolata Belgiana",
        quantity: 1,
        comment: "-",
      },
    ],
    completed: false,
  },
];

function generateUniqueTableNumber(arr: any): number {
  let randomNumber = Math.floor(Math.random() * 100);
  if (arr.filter((item: any) => item.tableNumber == randomNumber).length == 0)
    return randomNumber;
  else return generateUniqueTableNumber(arr);
}
function generateRandomMenuItems(): any {
  const randomNames = [
    "Pizza Pepperoni",
    "Pizza Bolognese",
    "Supa de pui",
    "Paste in sos de tomate",
    "Meniul zilei",
    "Specialitatea bucatarului",
    "Souvlaki",
    "Cascaval pane",
    "Ciorba de legume",
    "Tort de ciocolata",
  ];
  var outArr = [];
  for (let i = 0; i < Math.ceil(Math.random() * 10); i++) {
    outArr.push({
      name: randomNames[Math.floor(Math.random() * 10)],
      quantity: Math.ceil(Math.random() * 5),
      comments: "none",
    });
  }
  return outArr;
}

function generateOrders(nummberOfItems: number) {
  var outArr: any = [];
  for (let index = 1; index <= nummberOfItems; index++) {
    outArr.push({
      id: index,
      tableNumber: generateUniqueTableNumber(outArr),
      menuItems: generateRandomMenuItems(),
      completed: Math.floor(Math.random() * 10) % 2 == 0,
    });
  }
  return outArr;
}

const orderHistory = [
  {
    id: 1,
    tableNumber: 4,
    menuItems: [
      {
        name: "Pizza Pepperoni",
        quantity: 3,
        comment: "Doresc cu ulei de masline",
      },
      {
        name: "Clatite cu Finetti",
        quantity: 1,
        comment: "Si banane",
      },
      {
        name: "Inghetata din Ciocolata Belgiana",
        quantity: 1,
        comment: "-",
      },
    ],
    completed: true,
  },
  {
    id: 2,
    tableNumber: 4,
    menuItems: [
      {
        name: "Pizza Pepperoni",
        quantity: 2,
        comment: "Doresc cu ulei de masline",
      },
      {
        name: "Clatite cu Finetti",
        quantity: 1,
        comment: "Si banane",
      },
      {
        name: "Inghetata din Ciocolata Belgiana",
        quantity: 1,
        comment: "-",
      },
    ],
    completed: true,
  },
];
const generatedOrders = generateOrders(10);
console.log(generatedOrders);
export const ViewOrders = (props: ViewOrdersProps) => {
  if (props.employeeIsConnected == false) {
    alert("You must be logged in to view orders");
    return <Redirect to="/"></Redirect>;
  }
  return (
    <React.Fragment>
      <Container>
        <Row>
          <Col>
            <h1 className="centerAlign">Create a new menu item!</h1>
          </Col>
        </Row>
        <Row>
          <Col>
            {generatedOrders
              .filter((order: any) => order.completed == false)
              .map((order: any) => (
                <OrderItem
                  id={order.id}
                  tableNumber={order.tableNumber}
                  menuItems={order.menuItems}
                  completed={order.completed}
                />
              ))}
          </Col>
        </Row>
        <Row className="topPadding">
          <Col>
            <h1 className="centerAlign">Order History</h1>
          </Col>
        </Row>
        <Row>
          <Col>
            {generatedOrders
              .filter((order: any) => order.completed == true)
              .map((order: any) => (
                <OrderItem
                  id={order.id}
                  tableNumber={order.tableNumber}
                  menuItems={order.menuItems}
                  completed={order.completed}
                />
              ))}
          </Col>
        </Row>
      </Container>
    </React.Fragment>
  );
};
