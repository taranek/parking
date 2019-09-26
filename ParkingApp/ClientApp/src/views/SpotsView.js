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
    this.state = { spots: [], spotWithDetails:null, index:0, hideSpotsDetail:true, loading: true };
    this.state.loading = (this.state.bookings !=[]) &&(this.state.spots!=[])
    }
    componentDidMount(){
      fetch('api/spots')
      .then(response => response.json())
      .then(data => { this.setState({ spots: data}); }
    );
    }
    chooseSpot(i){
     this.setState(()=>({spotWithDetails:this.state.spots[i]}));
    //  alert(JSON.stringify(this.state.spotWithDetails));
    };

    renderSpots = (spot, i) =>{
      return (<Spot key={i} spot={spot} clicked={ ()=>this.chooseSpot(i)}></Spot>)
    }
    
    render() {
    return (
      <div>
        <h1>Spots View</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <Box m={2}>
            <SpotDetails spot={this.state.spotWithDetails}></SpotDetails>  
            </Box>
            <Grid container>
              { this.state.spots.map(this.renderSpots) }
            </Grid>
      </div>
    );
  }
}