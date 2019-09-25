import moment from 'moment';
import React, {Component} from 'react';
import Box from '@material-ui/core/Box';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import AddIcon from '@material-ui/icons/Add';
import Fab from '@material-ui/core/Fab';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import IconButton from '@material-ui/core/IconButton';
import Tooltip from '@material-ui/core/Tooltip';
import Button from '@material-ui/core/Button';
import { spacing } from '@material-ui/system';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import ExpansionPanel from '@material-ui/core/ExpansionPanel';
import ExpansionPanelSummary from '@material-ui/core/ExpansionPanelSummary';
import ExpansionPanelDetails from '@material-ui/core/ExpansionPanelDetails';
import Typography from '@material-ui/core/Typography';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel'
import FormControl from '@material-ui/core/FormControl'
import MaterialUIForm from 'react-material-ui-form'
 
export default class Booking extends Component {
  constructor(props){
    super(props);
    this.deleteBooking = this.deleteBooking.bind(this);
    this.handleEdit = this.handleEdit.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.getSpotDetails = this.getSpotDetails.bind(this);
    this.handleFormSubmission = this.handleFormSubmission.bind(this);
    this.state = {
      editMode:false,
      formChanged:false,
      booking:this.props.booking,
      editedBooking:this.props.booking,
      bookedSpot:{},
      loading:true,
    }
  }
  componentDidMount(){
    this.getSpotDetails();
  }
    isActive(){
        let start = moment(this.state.booking.dateStart);
        let end = moment(this.state.booking.dateEnd);
        var now = moment()
        if (now.isBetween(start,end)) return "Active";
        if (now.isAfter(end)) return "Past";
        return "Upcoming";
    };
    bookingColor(){
      var state = this.isActive();
      if(state=="Active") return "primary.main";
      if(state=="Upcoming") return "secondary.main";
      return "error.main";
    }
    handleEdit(){
      this.setState(prevState => ({editMode: !prevState.editMode}))
    }
    getSpotDetails(){
      if(this.state.loading){
        fetch('https://localhost:44391/api/spots/'+this.state.booking.spotId)
              .then(response => response.json())
              .then(data => { this.setState((state)=>({
                booking: {                   
                  ...state.booking,    
                  primaryOwner: data.primaryOwner,
                  code: data.code,
                  parkingLot: data.parkingLot,
                  company: data.company
                },
                loading: false})
              );
            })
            this.setState((state)=>({editedBooking:{...state.booking}}));
        this.forceUpdate();
      }
    }
    handleFormSubmission(){
      if(this.state.formChanged){
        fetch('https://localhost:44391/api/bookings/editbooking/'+this.state.editedBooking.id, {
          method: 'Put',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
           spotId : this.state.editedBooking.spotId,
           dateStart :this.state.editedBooking.dateStart,
           dateEnd : this.state.editedBooking.dateEnd,
           owner : this.state.editedBooking.owner,
          })
        })
      }

      this.setState(state =>({formChanged:false}));
    }
    deleteBooking() {
      alert('Attempting submitting');
      
    }

    handleChange(event){
      event.persist();  
      this.setState((state) => ({
        editedBooking: {                   
          ...state.editedBooking,    
          [event.target.id]: event.target.value   
      },
        formChanged:true,
      }));

  }
    render() {return (
<MaterialUIForm onSubmit={this.handleFormSubmission}>
<Box m={2}>
      <ExpansionPanel>
        <ExpansionPanelSummary
          expandIcon={<ExpandMoreIcon />}
          my={1}>
            <Box width="5%" p={2} >
              {this.state.booking.id}
            </Box>
            <Box color={this.bookingColor()} m={2}>
              <strong>{this.isActive()}</strong>
            </Box>
            <Box m={2}>
              <strong>{this.state.booking.owner}'s</strong>
              &nbsp;booking on &nbsp;
              <strong>{this.state.booking.primaryOwner}'s</strong>
              &nbsp;place
            </Box>
          </ExpansionPanelSummary>
        <ExpansionPanelDetails>
        <Grid container spacing={3}>
          <Grid item xs={3}>
            <TextField id="owner"
              fullWidth variant= {this.state.editMode? "outlined": "filled"}
              label="Booked by"
              value={this.state.editedBooking.owner}
              onChange={this.handleChange}
              InputProps={{readOnly: !this.state.editMode}}/>
          </Grid>
          <Grid item xs={3}>
            <TextField
                id="dateStart"
                fullWidth variant= {this.state.editMode? "outlined": "filled"}
                label="From"
                value={this.state.editedBooking.dateStart}
                onChange={this.handleChange}
                InputProps={{readOnly: !this.state.editMode}}/>
          </Grid>
          <Grid item xs={3}>
          <TextField
                id="dateEnd"
                fullWidth variant= {this.state.editMode? "outlined": "filled"}
                label="To"
                value={this.state.editedBooking.dateEnd}
                onChange={this.handleChange}
                InputProps={{ readOnly: !this.state.editMode, shrink: true,}}/>
          </Grid>
          <Grid item xs={3}>
          <Box p={1}>
              <Button
               size="large"
              type="submit"
              variant="contained" 
              color={this.state.editMode? "primary":"default"}
              onClick={this.handleEdit}>
                 {this.state.formChanged? "Submit changes" : "Edit"}
                <EditIcon/>
              </Button>
            </Box>
          </Grid>
          <Grid item xs={3}>
          <TextField
              id="primaryOwner"
              label="Primary owner of the spot"
              fullWidth variant="filled"
              defaultValue = "primaryOwner"
              value={this.state.editedBooking.primaryOwner? this.state.editedBooking.primaryOwner : this.state.booking.primaryOwner}
              onChange={this.handleChange}
              InputProps={{readOnly: true}}/>
          </Grid>
          <Grid item xs={3}>
          <TextField
              id="code"
              label="Spot code"
              fullWidth variant="filled"
              defaultValue = "spotId"
              value={this.state.editedBooking.code? this.state.editedBooking.code : this.state.booking.code}
              onChange={this.handleChange}
              InputProps={{readOnly: true}}/>
          </Grid>
          <Grid item xs={3}>
          <TextField
              id="parkingLot"
              label="Parking lot"
              fullWidth variant="filled"
              defaultValue = "parkingLot"
              value={this.state.editedBooking.parkingLot? this.state.editedBooking.parkingLot : this.state.booking.parkingLot}
              onChange={this.handleChange}
              InputProps={{readOnly: true}}/>
          </Grid>
          <Grid item xs={3}>
          <Box p={1}>
          <Button 
            size="large"
            variant="contained" 
            color="secondary" 
            onClick={this.deleteBooking}>
               Delete
              <DeleteIcon/>
            </Button>
            </Box> 
          </Grid>
        </Grid>
        </ExpansionPanelDetails>
      </ExpansionPanel>
      </Box>
      </MaterialUIForm>
    );}
};