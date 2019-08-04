import React, { Component } from 'react';

export class SpotsView extends Component {
  displayName = SpotsView.name

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
        let spotsTable = SpotsView.renderspotsTable(this.state.spots);

          //this.state.loading
          //? <p><em>Loading...</em></p>
          //: FetchData.renderspotsTable(this.state.spots);


    return (
      <div>
        <h1>Spots View</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {spotsTable}
      </div>
    );
  }
}
