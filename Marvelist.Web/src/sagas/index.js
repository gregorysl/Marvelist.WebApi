import { fork} from 'redux-saga/effects';
import { fetchSeriesByIdFlow, fetchSeriesFlow} from './seriesSagas';



export default [
  fork(fetchSeriesByIdFlow), 
  fork(fetchSeriesFlow)
];

