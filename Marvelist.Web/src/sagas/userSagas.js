import { take, call, put, race } from 'redux-saga/effects';
import history from '../history';
import auth from '../auth';
import {
  SENDING_REQUEST,
  LOGIN_REQUEST,
  REGISTER_REQUEST,
  SET_AUTH,
  SET_USER,
  LOGOUT,
  REQUEST_ERROR
} from '../actions/constants';

export function* authorize({ email, username, password, isRegistering }) {
  yield put({ type: SENDING_REQUEST, sending: true });

  try {
    let response;

    if (isRegistering) {
      response = yield call(auth.register, username, password, email);
    } else {
      response = yield call(auth.login, username, password);
    }
    return response;
  } catch (error) {
    yield put({ type: REQUEST_ERROR, error: error });
    return false;
  } finally {
    yield put({ type: SENDING_REQUEST, sending: false });
  }
}
export function* logout() {
  yield put({ type: SENDING_REQUEST, sending: true });
  try {
    let response = yield call(auth.logout);
    yield put({ type: SENDING_REQUEST, sending: false });
    return response;
  } catch (error) {
    yield put({ type: REQUEST_ERROR, error: error.message });
  }
}
function forwardTo(location) {
  history.push(location);
}

export function* loginFlow() {
  for (; ;) {
    let request = yield take(LOGIN_REQUEST);
    let { username, password } = request.data;
    let winner = yield race({
      auth: call(authorize, { username, password, isRegistering: false }),
      logout: take(LOGOUT)
    });
    if (winner.auth) {
      yield put({ type: SET_AUTH, newAuthState: true });
      yield put({ type: SET_USER, username: winner.auth.data.userName });
      forwardTo('/');
    } else if (winner.logout) {
      yield put({ type: SET_AUTH, newAuthState: false });
      yield call(logout);
      forwardTo('/');
    }
  }
}

export function* logoutFlow() {
  for (; ;) {
    yield take(LOGOUT);
    yield put({ type: SET_AUTH, newAuthState: false });
    yield call(logout);
    forwardTo('/');
  }
}

export function* registerFlow() {
  for (; ;) {
    let request = yield take(REGISTER_REQUEST);
    let { email, username, password } = request.data;

    let wasSuccessful = yield call(authorize, { email, username, password, isRegistering: true });

    if (wasSuccessful) {
      yield put({ type: SET_AUTH, newAuthState: true });
      forwardTo('/');
    }
  }
}