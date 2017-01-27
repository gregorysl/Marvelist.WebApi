import { combineReducers } from 'redux';
import {booksReducer, bookReducer} from './bookReducers';
import {seriesReducer, seriesDetailsReducer} from './seriesReducer';
import userReducer from './userReducer';

export default combineReducers({
  books: booksReducer,
  book: bookReducer,
  series: seriesReducer,
  seriesDetails: seriesDetailsReducer,
  user:userReducer
});