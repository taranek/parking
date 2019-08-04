import React, { Component } from 'react';

import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './SelectedListItem.js';
import './NavMenu.css';
import SelectedListItem from './SelectedListItem.js';

export class NavMenu extends Component {
    displayName = NavMenu.name

    render() {
        return (
            <Navbar inverse fixedTop fluid collapseOnSelect>
                <SelectedListItem></SelectedListItem>
            </Navbar>
        );
    }
}