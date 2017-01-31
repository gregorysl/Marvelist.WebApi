import {
  CHANGE_FORM,
  SET_AUTH,
  SET_USER,
  SENDING_REQUEST,
  REQUEST_ERROR,
  CLEAR_ERROR
} from '../actions/constants';
import auth from '../auth';

let initialState = {
  formState: {
    username: '',
    password: ''
  },
  error: '',
  currentlySending: false,
  loggedIn: auth.loggedIn(),
  username: auth.username()
};

function userReducer (state = initialState, action) {
  switch (action.type) {
    case CHANGE_FORM:
      return {...state, formState: action.newFormState};
    case SET_AUTH:
      return {...state, loggedIn: action.newAuthState};
    case SET_USER:
      return {...state, username:action.username};
    case SENDING_REQUEST:
      return {...state, currentlySending: action.sending};
    case REQUEST_ERROR:
      return {...state, error: action.error};
    case CLEAR_ERROR:
      return {...state, error: ''};
    default:
      return state;
  }
}

export default userReducer;
