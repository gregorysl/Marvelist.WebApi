import React from 'react';
import { Route, IndexRoute } from 'react-router';
import App from './components/App';
import Home from './components/common/HomePage';
import About from './components/common/AboutPage';
import Series from './components/series/SeriesPage';
import SeriesDetails from './components/series/SeriesDetailPage';

export default (
  <Route path="/" component={App}>
    <IndexRoute component={Home} />
    <Route path="/about" component={About} />
    <Route path="/series" component={Series} />
    <Route path="/series/:id" component={SeriesDetails} />
  </Route>
);
