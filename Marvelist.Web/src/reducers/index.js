import { combineReducers } from 'redux';
import {booksReducer, bookReducer} from './bookReducers';
import {seriesReducer} from './seriesReducer';

export default combineReducers({
  books: booksReducer,
  book: bookReducer,
  series: seriesReducer
});