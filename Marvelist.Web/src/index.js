import 'babel-polyfill';
import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { Router, browserHistory } from 'react-router';
import routes from './routes';
import configureStore from './store/configureStore';
import { LocaleProvider } from 'antd';
import { syncHistoryWithStore } from 'react-router-redux';
import enUS from 'antd/lib/locale-provider/en_US';
import 'antd/dist/antd.less';
import './styles/main.less';
require('./favicon.ico');

const store = configureStore();
const history = syncHistoryWithStore(browserHistory, store);

render(
  <LocaleProvider locale={enUS}>
    <Provider store={store}>
      <Router history={history} routes={routes} />
    </Provider>
  </LocaleProvider>,
  document.getElementById('app')
);
