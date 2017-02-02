import { fork } from 'redux-saga/effects';
import { loginFlow, logoutFlow, registerFlow } from './userSagas';
import { fetchSeriesByIdFlow, fetchSeriesFlow, followSeriesFlow } from './seriesSagas';



export default [
  fork(loginFlow),
  fork(logoutFlow),
  fork(registerFlow),
  fork(fetchSeriesByIdFlow),
  fork(fetchSeriesFlow),
  fork(followSeriesFlow)
];