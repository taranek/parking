import React, { Component } from "react";
import Box from "@material-ui/core/Box";
import Spot from "../components/Spot";
import SpotDetails from "../components/SpotDetails";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import CustomizedSnackbars from "../components/CustomizedSnackbars";

export class SpotsView extends Component {
  displayName = SpotsView.name;

  constructor(props) {
    super(props);

    this.chooseSpot = this.chooseSpot.bind(this);
    this.renderSpots = this.renderSpots.bind(this);
    this.state = {
      spots: [],
      spotWithDetails: null,
      index: 0,
      hideSpotsDetail: true,
      loading: true
    };
    this.state.loading = this.state.bookings != [] && this.state.spots != [];
  }
  componentDidMount() {
    fetch("api/spots",
    {
      method: "Get",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      }})
      .then(response => {
        if (!response.ok) throw new Error(response.url + " "+ response.status + " "+ response.statusText);
        else return response.json();
      })
      .then(data => {
        this.setState({ spots: data });
      })
      .catch(err => {
        this.setState(state => ({
          ...state,
          requestInProgress: false,
          requestFailed: false,
          errors: "There was an error when fetching data: "+err,
        }));
      });
  }
  chooseSpot(i) {
    this.setState(() => ({ spotWithDetails: this.state.spots[i] }));
    //  alert(JSON.stringify(this.state.spotWithDetails));
  }
  handleDetailsForm = (response) => {
    if(response.isSuccess){
      this.setState({
        info:response.data
      });
    }
    else{
      this.setState({
        errors:(response.errors)
      });
    }
    

  }
  renderSpots = (spot, i) => {
    return (
      <Spot key={i} spot={spot} _onClick={() => this.chooseSpot(i)}></Spot>
    );
  };

  render() {
    return (
      <div>
        <h1>Spots View</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <Box m={2}>
          <SpotDetails onFormSubmitted={this.handleDetailsForm} spot={this.state.spotWithDetails}></SpotDetails>
        </Box>
        <Grid container>{this.state.spots? this.state.spots.map(this.renderSpots): null}</Grid>
        <div>
          {this.state.errors ? (
            <div>
              <CustomizedSnackbars
                open={true}
                duration={2500}
                message={this.state.errors}
                onClose={() => {this.setState(state => ({
                  ...state,
                  errors: null,}))}}
                variant="error"
              ></CustomizedSnackbars>
            </div>
          ) : null}
          {this.state.info ? (
            <div>
              <CustomizedSnackbars
                open={true}
                duration={2500}
                message={this.state.info}
                onClose={() => {this.setState(state => ({
                  ...state,
                  info: null,}))}}
                variant="success"
              ></CustomizedSnackbars>
            </div>
          ) : null}
        </div>
      </div>
    );
  }
}
