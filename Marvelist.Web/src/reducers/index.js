import { combineReducers } from 'redux';
import {seriesReducer, seriesDetailsReducer} from './seriesReducer';
import userReducer from './userReducer';

export default combineReducers({
  series: seriesReducer,
  seriesDetails: seriesDetailsReducer,
  user:userReducer
});