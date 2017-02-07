import { combineReducers } from 'redux';
import { seriesReducer, seriesDetailsReducer, homeComicsReducer } from './seriesReducer';
import userReducer from './userReducer';

export default combineReducers({
  series: seriesReducer,
  seriesDetails: seriesDetailsReducer,
  user: userReducer,
  homeComics: homeComicsReducer
});