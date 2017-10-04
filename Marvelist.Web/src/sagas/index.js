import { fork } from 'redux-saga/effects';
import { loginFlow, logoutFlow, registerFlow } from './userSagas';
import * as series from './seriesSagas';



export default [
  fork(loginFlow),
  fork(logoutFlow),
  fork(registerFlow),
  fork(series.fetchSeriesByIdFlow),
  fork(series.fetchSeriesByYearFlow),
  fork(series.fetchSeriesFlow),
  fork(series.followSeriesFlow),
  fork(series.followComicFlow),
  fork(series.fetchHomeFlow),
  fork(series.searchFlow),
  fork(series.readAllComicsFlow)
];