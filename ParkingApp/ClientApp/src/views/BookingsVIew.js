import React, { Component } from 'react';
import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Booking from '../components/Booking';


  const styles = {
      background: "linear-gradient(45deg, rgba(255,0,0,1) 0%, rgba(223,11,54,1) 50%, rgba(248,0,255,1) 100%)",
      borderRadius: 3,
      border: 0,
      color: "white",
      height: 60,
      width:60,
      boxShadow: "0 3px 5px 2px rgba(255, 105, 135, .3)",
      borderRadius: 50,
      float:"left",
  };
  const list = {
      width: '100%',
      maxWidth: 200,
      backgroundColor: "rgb(240,240,240)",
  };
  const item = {
      fontSize:0,
  }

  // const useStyles = makeStyles(theme => ({
  //   root: {
  //     width: '100%',
  //     maxWidth: 360,
  //     backgroundColor: theme.palette.background.paper,
  //   },
  // }));
  // const classes = useStyles();

export class BookingsView extends Component {
  displayName = BookingsView.name

  constructor(props) {
    super(props);
      this.state = { spots: [], bookings: [], loading: true };
      fetch('api/bookings')
          .then(response => response.json())
          .then(data => { this.setState({ bookings: data, loading: false }); }
      );
      this.state.loading = (this.state.bookings !=[]) &&(this.state.spots!=[])
    }

    static renderBookingTable(bookings) {
        return (
          <List component="nav" aria-label="contacts">
          {bookings.map(booking=>
            <ListItem style={item} button>
              <ListItemText style={item} primary={booking.owner} />
            </ListItem>)}
        </List>
        );
    }

    render() {
        let bookingTable = BookingsView.renderBookingTable(this.state.bookings);
    return (
      <div>
        <h1>Bookings Views</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {this.state.bookings.map(booking => <Booking booking={booking}></Booking>)}
      </div>
    );
  }
}
