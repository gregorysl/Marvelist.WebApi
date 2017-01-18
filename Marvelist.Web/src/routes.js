import React from 'react';
import { Route, IndexRoute } from 'react-router';
import App from './components/App';
import Home from './components/common/HomePage';
import About from './components/common/AboutPage';
import Book from './components/book/BookPage';
import Series from './components/series/SeriesPage';
import BookDetailsPage from './components/book/BookDetailsPage';

export default (
  <Route path="/" component={App}>
    <IndexRoute component={Home} />
    <Route path="/about" component={About} />
    <Route path="/books" component={Book} />
    <Route path="/books/:id" component={BookDetailsPage} />
    <Route path="/series" component={Series}></Route>
  </Route>
);
