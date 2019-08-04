import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { BookingsView } from './components/BookingsVIew';
import { Counter } from './components/Counter';
import { SpotsView } from './components/SpotsView';
import 'typeface-roboto';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/bookings' component={BookingsView} />
        <Route path='/spots' component={SpotsView} />
      </Layout>
    );
  }
}
