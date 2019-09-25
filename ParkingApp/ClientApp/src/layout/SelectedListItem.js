import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Divider from '@material-ui/core/Divider';
import InboxIcon from '@material-ui/icons/Inbox';
import DraftsIcon from '@material-ui/icons/Drafts';
import { Link } from 'react-router-dom';
import Collapse from '@material-ui/core/Collapse';
import SendIcon from '@material-ui/icons/Send';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import StarBorder from '@material-ui/icons/StarBorder';
const useStyles = makeStyles(theme => ({
  root: {
    width: '100%',
    backgroundColor: theme.palette.background.paper,
  },  nested: {
    paddingLeft: theme.spacing(4),
  },
}));

export default function SelectedListItem() {
  const classes = useStyles();
  const [selectedIndex, setSelectedIndex] = React.useState([]);

  function handleListItemClick(event, index) {
    setSelectedIndex(index);
  }

 
  return (
    <div className={classes.root}>
      <List component="nav" aria-label="main mailbox folders">
      <Link to="" style={{color: 'black'}} activeStyle={{color: 'red'}}>
      <ListItem
          button>
          <ListItemIcon>
            <InboxIcon />
          </ListItemIcon>
          <ListItemText primary="Home" />
      </ListItem>
      </Link>
        <ListItem
          button
          selected={selectedIndex === 0}
          onClick={event => handleListItemClick(event, 0)}>
          <ListItemIcon>
            <InboxIcon />
          </ListItemIcon>
          <ListItemText primary="Bookings" />
          {selectedIndex === 0 ? <ExpandLess /> : <ExpandMore />}
        </ListItem>
        <Collapse in={selectedIndex === 0} timeout="auto" unmountOnExit>
          <Link to="/bookings" style={{color: 'black'}} activeStyle={{color: 'red'}}>
          <ListItem button className={classes.nested}>
            <ListItemIcon>
              <StarBorder />
            </ListItemIcon>
            <ListItemText primary="All bookings" />
          </ListItem>
          </Link>
      </Collapse>
        <ListItem button selected={selectedIndex === 1}
          onClick={event => handleListItemClick(event, 1)}>
        <ListItemIcon>
          <InboxIcon />
        </ListItemIcon>
        <ListItemText primary="Spots" />
        {selectedIndex === 1 ? <ExpandLess /> : <ExpandMore />}
      </ListItem>
      <Collapse in={selectedIndex === 1} timeout="auto" unmountOnExit>
      <Link to="/spots" style={{color: 'black'}} activeStyle={{color: 'red'}}>
          <ListItem button className={classes.nested}>
            <ListItemIcon>
              <StarBorder />
            </ListItemIcon>
            <ListItemText primary="My parking lot" />
          </ListItem>
          </Link>
      </Collapse>
      <Collapse in={selectedIndex === 1} timeout="auto" unmountOnExit>
          <ListItem button className={classes.nested}>
            <ListItemIcon>
              <StarBorder />
            </ListItemIcon>
            <ListItemText primary="Add new spot" />
          </ListItem>
      </Collapse>
      </List>
      <Divider />
      <List component="nav" aria-label="secondary mailbox folder">
      </List>
    </div>
  );
}