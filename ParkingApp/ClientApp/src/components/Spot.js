import React, { Component } from 'react';
import Box from '@material-ui/core/Box';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import AddIcon from '@material-ui/icons/Add';
import Fab from '@material-ui/core/Fab';
import DeleteIcon from '@material-ui/icons/Delete';
import IconButton from '@material-ui/core/IconButton';
import Tooltip from '@material-ui/core/Tooltip';
import Button from '@material-ui/core/Button';
import { spacing } from '@material-ui/system';
import DriveEtaIcon from '@material-ui/icons/DriveEta';
import ButtonBase from '@material-ui/core/ButtonBase';
import Grid from '@material-ui/core/Grid'

export default class Spot extends Component {
  constructor(props) {
      super(props);
      this.state ={ spot:this.props.spot,
                    isFree:(this.props.spot.primaryOwner==null || this.props.spot.primaryOwner.trim().length==0)}
  };    
  render(){
    return (
    <Grid item xs={1} >
      <Tooltip title={this.state.isFree ? 'FREE' : this.state.spot.primaryOwner}  >
      <ButtonBase bgcolor={this.state.isFree ? 'primary.main' : 'secondary'}>
      <Box height={'50px'} key={this.props.key} onClick={this.props.clicked} 
      display='flex' flexDirection='column'alignItems="center" justifyContent="center" 
      bgcolor={this.state.isFree? 'primary.main' : 'secondary.main'} color='white' p={1}>
        <div>
          {this.state.isFree? null: <DriveEtaIcon></DriveEtaIcon> }
          </div>
          <div>
          {this.state.spot.code}
          </div>
      </Box>
      </ButtonBase>
      </Tooltip>
    </Grid>
  )}
};
