import 'babel-polyfill';
import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { Router, browserHistory } from 'react-router';
import routes from './routes';
import configureStore from './store/configureStore';
import { LocaleProvider } from 'antd';
import enUS from 'antd/lib/locale-provider/en_US';
import 'antd/dist/antd.less';
import './styles/main.less';

const store = configureStore();

render(
  <LocaleProvider locale={enUS}>
    <Provider store={store}>
      <Router history={browserHistory} routes={routes} />
    </Provider>
  </LocaleProvider>,
  document.getElementById('app')
);
