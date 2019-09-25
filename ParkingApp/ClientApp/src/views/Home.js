import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';

  const styles = {
      background:"rgb(0,0,0)",
      // background: "linear-gradient(45deg, rgba(255,0,0,1) 0%, rgba(223,11,54,1) 50%, rgba(248,0,255,1) 100%)",
      borderRadius: 3,
      border: 0,
      color: "white",
      height: 60,
      width:60,
      boxShadow: "0 3px 5px 2px rgba(255, 105, 135, .3)",
      borderRadius: 50,
  };
export class Home extends Component {
  displayName = Home.name;
  
  render() {
    return (
      <div>
        <h1>Hello, world!</h1>
      </div>
    );
  }
}
