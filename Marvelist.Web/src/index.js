import 'babel-polyfill';
import React from 'react';
import { render } from 'react-dom';
import {Provider } from 'react-redux';
import { Router, browserHistory } from 'react-router';
import routes from './routes';
import './styles/styles.css'; //Webpack can import CSS files too!
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import * as bookActions from './actions/bookActions';
import * as seriesActions from './actions/seriesActions';

import configureStore from './store/configureStore';

const store = configureStore();
store.dispatch(bookActions.fetchBooks());
store.dispatch(seriesActions.fetchSeries());

render(
  <Provider store={store}>
    <Router history={browserHistory} routes={routes} />
  </Provider>,
  document.getElementById('app')
);
