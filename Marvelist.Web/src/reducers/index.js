import { combineReducers } from 'redux';
import { seriesReducer, seriesDetailsReducer, homeComicsReducer,weekComicsReducer } from './seriesReducer';
import userReducer from './userReducer';
import {routerReducer} from 'react-router-redux';

export default combineReducers({
  series: seriesReducer,
  seriesDetails: seriesDetailsReducer,
  user: userReducer,
  homeComics: homeComicsReducer,
  routing: routerReducer,
  week: weekComicsReducer
});