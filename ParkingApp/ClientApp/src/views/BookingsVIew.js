import React, { Component } from 'react';
import Booking from '../components/Booking';

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

    render() {
    return (
      <div>
        <h1>Bookings Views</h1>
            <p>This view is to show bookings made by user.</p>
            {this.state.bookings.map(booking => <Booking booking={booking}></Booking>)}
      </div>
    );
  }
}
