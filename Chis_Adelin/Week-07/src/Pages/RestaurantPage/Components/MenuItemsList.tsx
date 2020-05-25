import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { MenuItem } from "../../../Models/MenuItemModel";
import { Col, Row } from "react-bootstrap";
import { MenuItemPreviewComponent } from "../../../Components/MenuItemPreview";

type MenuItemsListProps = {
    items: MenuItem[]
};
export const MenuItemsListComponent = (props: MenuItemsListProps) => {
    return (
        <Row>
            <React.Fragment>
                {props.items.map(item => (
                    <Col lg={4} md={6} sm={12}>
                        <MenuItemPreviewComponent item={item} />
                    </Col>
                ))}
            </React.Fragment>
        </Row>
    )
};