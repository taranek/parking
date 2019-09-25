import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import TextField from '@material-ui/core/TextField';

export default class SpotDetails extends Component {
    constructor(props) {
        super(props);
    };    
    render() { if(this.props.spot != null){
        return (
    <div>
        <Grid container spacing={3} xs={6}>
            <Grid item xs={6}>
                <TextField id="standard-read-only-input"
                    fullWidth variant="outlined"
                    label="Primary owner"
                    defaultValue={this.props.spot.primaryOwner}
                    InputProps={{ 
                    readOnly: true}}/>
            </Grid>
            <Grid item xs={6}>
                <TextField id="standard-read-only-input"
                    fullWidth variant="outlined"
                    label="Company"
                    defaultValue={this.props.spot.company}
                    InputProps={{ 
                    readOnly: true}}/>
            </Grid>
            <Grid item xs={6}>
                <TextField id="standard-read-only-input"
                    fullWidth variant="outlined"
                    label="Parking lot"
                    defaultValue={this.props.spot.parkingLot}
                    InputProps={{ 
                    readOnly: true}}/>
            </Grid>
            <Grid item xs={6}>
                <TextField id="standard-read-only-input"
                    fullWidth variant="outlined"
                    label="Level"
                    defaultValue={this.props.spot.level}
                    InputProps={{ 
                    readOnly: true}}/>
            </Grid>
            <Grid item xs={6}>
                <TextField id="standard-read-only-input"
                    fullWidth variant="outlined"
                    label="Booked by"
                    defaultValue="Props"
                    InputProps={{ 
                    readOnly: true}}/>
            </Grid>
            <Grid item xs={6}>
                <TextField id="standard-read-only-input"
                    fullWidth variant="outlined"
                    label="Booked by"
                    defaultValue="Props"
                    InputProps={{ 
                    readOnly: true}}/>
            </Grid>
        </Grid>
            </div>
        )}
        else return (<div>No spot</div>);
    }
}