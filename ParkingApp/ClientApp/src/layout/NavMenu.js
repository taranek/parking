import React, { Component } from 'react';

import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './MenuList.js';
import './NavMenu.css';
import MenuList from './MenuList.js';

export class NavMenu extends Component {
    displayName = NavMenu.name

    render() {
        return (
            <Navbar inverse fixedTop fluid collapseOnSelect>
                <MenuList></MenuList>
            </Navbar>
        );
    }
}