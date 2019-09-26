import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import MaterialUIForm from 'react-material-ui-form'

export default class SpotDetails extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
        this.handleEdit = this.handleEdit.bind(this);
        this.handleFormSubmission = this.handleFormSubmission.bind(this);
        this.state = {
            editedSpot: this.props.spot,
            editMode:false,
            newSpotLoaded:false,
        }
    };
    handleFormSubmission(){
  
        if(this.state.formChanged){
          fetch('https://localhost:44391/api/spots/edit/'+this.state.editedSpot.id, {
            method: 'Put',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
             code : this.state.editedSpot.code,
             level :this.state.editedSpot.level,
             primaryOwner : this.state.editedSpot.primaryOwner,
             parkingLot : this.state.editedSpot.parkingLot,
             company: this.state.editedSpot.company,
            })
          })
          this.forceUpdate();
        }
    }
    componentDidUpdate(prevProps){
        if(!this.props.spot) return;

        if(!prevProps.spot){
            this.setState(()=>({
                editedSpot:this.props.spot,}))
        }
        if (this.props.spot && prevProps.spot && (this.props.spot.id !== prevProps.spot.id)) {
          this.setState(()=>({
              editedSpot:this.props.spot,
              newSpotLoaded:true,
              editMode:false,
        }));
        }
    }
    handleChange(event){
        event.persist();  
        this.setState((state) => ({
          editedSpot: {                   
            ...state.editedSpot,    
            [event.target.id]: event.target.value   
        },
          formChanged:true,
        }));
    }
    handleEdit(){
        this.setState(prevState => ({editMode: !prevState.editMode}))
      }
    render() { if(this.props.spot && this.state.editedSpot){
        return (
    <MaterialUIForm onSubmit={this.handleFormSubmission}>
        <Grid container spacing={3} xs={6}>
            <Grid item xs={6}>
                <TextField                
                id="primaryOwner"
                fullWidth variant= {this.state.editMode? "outlined": "filled"}
                label="Primary Owner"
                value={this.state.editedSpot.primaryOwner}
                onChange={this.handleChange}
                InputProps={{readOnly: !this.state.editMode}}/>
            </Grid>
            <Grid item xs={6}>
                <TextField                
                id="company"
                fullWidth variant= {this.state.editMode? "outlined": "filled"}
                label="Company"
                value={this.state.editedSpot.company}
                onChange={this.handleChange}
                InputProps={{readOnly: !this.state.editMode}}/>
            </Grid>
            <Grid item xs={6}>
            <TextField                
                id="parkingLot"
                fullWidth variant= {this.state.editMode? "outlined": "filled"}
                label="Parking lot"
                value={this.state.editedSpot.parkingLot}
                onChange={this.handleChange}
                InputProps={{readOnly: !this.state.editMode}}/>
            </Grid>
            <Grid item xs={6}>
            <TextField                
                id="level"
                fullWidth variant= {this.state.editMode? "outlined": "filled"}
                label="Level"
                value={this.state.editedSpot.level }
                onChange={this.handleChange}
                InputProps={{readOnly: !this.state.editMode}}/>
            </Grid>
            <Grid item xs={6}>
            <TextField                
                id="code"
                fullWidth variant= {this.state.editMode? "outlined": "filled"}
                label="Spot code"
                value={this.state.editedSpot.code}
                onChange={this.handleChange}
                InputProps={{readOnly: !this.state.editMode}}/>
            </Grid>
            <Grid item xs={6}>
            <Button
               size="large"
              type="submit"
              variant="contained" 
              color={this.state.editMode? "primary":"default"}
              onClick={this.handleEdit}>
                 {this.state.formChanged? "Submit changes" : "Edit"}
                <EditIcon/>
              </Button>
            </Grid>
        </Grid>
    </MaterialUIForm>
        )}
        else return (<div>No spot</div>);
    }
}