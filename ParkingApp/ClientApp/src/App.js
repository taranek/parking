import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './layout/Layout';
import { Home } from './views/Home';
import { BookingsView } from './views/BookingsVIew';
import { SpotsView } from './views/SpotsView';
import 'typeface-roboto';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/bookings' component={BookingsView} />
        <Route path='/spots' component={SpotsView} />
      </Layout>
    );
  }
}
