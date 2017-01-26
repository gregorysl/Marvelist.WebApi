import {createStore, compose, applyMiddleware} from 'redux';
import createSagaMiddleware from 'redux-saga';
import rootReducer from '../reducers';
import allSagas from '../sagas';

const configureStore = (initialState) => {
  const saga = createSagaMiddleware();
  const store = createStore(
    rootReducer,
    initialState,
    applyMiddleware(saga)
  );
  saga.run(function * () {
    yield allSagas;
  }); 
  return store;
};

export default configureStore;
