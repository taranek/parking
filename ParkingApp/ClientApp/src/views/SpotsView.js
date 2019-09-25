import React, { Component } from 'react';
import Box from '@material-ui/core/Box';
import Spot from '../components/Spot';
import SpotDetails from '../components/SpotDetails';
import Grid from '@material-ui/core/Grid'
export class SpotsView extends Component {
  displayName = SpotsView.name

  constructor(props) {
    super(props);
    
    this.chooseSpot = this.chooseSpot.bind(this);
    this.renderSpots = this.renderSpots.bind(this);
      this.state = { spots: [], choosenSpot:null, bookings: [], hideSpotsDetail:true, loading: true };


    fetch('api/spots')
          .then(response => response.json())
          .then(data => { this.setState({ spots: data}); }
      );
      this.state.loading = (this.state.bookings !=[]) &&(this.state.spots!=[])
    }
    chooseSpot(){
     alert('Spot has been chosen');
    };
    renderSpots = (spot, i) =>{
      return (<Spot key={i} spot={spot} onClick={()=>(alert('THAT IS NOT BEING TRIGGERED CORRECTLY'))}></Spot>)
    }
    render() {
    return (
      <div>
        <h1>Spots View</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <SpotDetails spot={this.state.choosenSpot}></SpotDetails>
            <Grid container>
              {this.state.spots
              .map(this.renderSpots)}
            </Grid>
      </div>
    );
  }
}