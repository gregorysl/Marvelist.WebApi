import 'babel-polyfill';
import React from 'react';
import { render } from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import configureStore from './store/configureStore';
import { LocaleProvider } from 'antd';
import { ConnectedRouter } from 'react-router-redux';
import { Provider } from 'react-redux';
import App from './components/App';
import history from './history';

import enUS from 'antd/lib/locale-provider/en_US';
import 'antd/dist/antd.less';
import './styles/main.less';
require('./favicon.ico');

const store = configureStore();

render(
  <LocaleProvider locale={enUS}>
  <AppContainer>
    <Provider store={store}>
      <ConnectedRouter history={history} >
      <App/>
      </ConnectedRouter>
    </Provider>
    </AppContainer>
  </LocaleProvider>,
  document.getElementById('app')
);
