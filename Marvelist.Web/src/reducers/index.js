import { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';
import account from './account';


export default combineReducers({
  form: formReducer,
  account
});
