import React, { Component } from 'react';

export class Test extends Component {
  displayName = Test.name

  constructor(props) {
    super(props);
      this.state = { spots: [], bookings: [], loading: true };

    fetch('api/spots')
          .then(response => response.json())
          .then(data => { this.setState({ spots: data}); }
      );
    fetch('api/bookings')
          .then(response => response.json())
          .then(data => { this.setState({ bookings: data, loading: false }); }
      );
      this.state.loading = (this.state.bookings !=[]) &&(this.state.spots!=[])
    }

    static renderBookingTable(bookings) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Spot Id</th>
                        <th>Date</th>
                        <th>Owner</th>
                    </tr>
                </thead>
                <tbody>
                    {bookings.map(booking =>
                        <tr key={booking.id}>
                            <td>{booking.id}</td>
                            <td>{booking.spotId}</td>
                            <td>{booking.date}</td>
                            <td>{booking.owner}</td>
                            <td> <button onClick={function () {
                                alert(booking.id);
                            }}>Edit</button> </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
  static renderspotsTable(spots) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Code</th>
            <th>Level</th>
            <th>Primary Owner</th>
            <th>Parking Lot</th>
            <th>Company</th>
            <th>Edit</th>
          </tr>
        </thead>
        <tbody>
          {spots.map(spot =>
            <tr key={spot.id}>
              <td>{spot.id}</td>
              <td>{spot.code}</td>
              <td>{spot.level}</td>
              <td>{spot.primaryOwner}</td>
              <td>{spot.parkingLot}</td>
              <td>{spot.company}</td>
                        <td> <button onClick={function () {
                            alert(spot.id);
                        }}>Edit</button> </td>
            </tr>
          )}
        </tbody>
      </table>
      
    );
  }
    render() {
        let bookingTable = Test.renderBookingTable(this.state.bookings);
        let spotsTable = Test.renderspotsTable(this.state.spots);

          //this.state.loading
          //? <p><em>Loading...</em></p>
          //: FetchData.renderspotsTable(this.state.spots);


    return (
      <div>
        <h1>Weather spot</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {bookingTable}
            {spotsTable}
      </div>
    );
  }
}
