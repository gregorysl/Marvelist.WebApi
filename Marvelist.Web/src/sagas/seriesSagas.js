import {take, call, put, fork, race} from 'redux-saga/effects';
import {browserHistory} from 'react-router';
import Axios from 'axios';
import auth from '../auth';
import {FETCH_SERIES_BY_ID, FETCH_SERIES, FETCH_SERIES_SUCCESS, FETCH_SERIES_BY_ID_SUCCESS} from '../actions/constants';

const apiUrl = "http://587f7cab402f50120072c974.mockapi.io/series";

function fetchSeries() {
    return Axios
        .get(apiUrl)
        .catch(error => {
            throw(error);
        });
}
export function * fetchSeriesFlow() {
    for (;;) {
        yield take(FETCH_SERIES);
        try {
            let response = yield call(fetchSeries);
            yield put({type: FETCH_SERIES_SUCCESS, series: response.data});
            return response;
        } catch (error) {
            let a = 1;
        }
    }
}

export function * fetchSeriesByIdFlow(id) {
    for (;;) {
        yield take(FETCH_SERIES_BY_ID);
        try {
            let response = yield call(fetchSeriesById, id);
            yield put({type: FETCH_SERIES_BY_ID_SUCCESS, seriesDetails: response.data[0]});
            return response;
        } catch (error) {
            let a = 1;
        }
    }
}

function fetchSeriesById(seriesId) {
    const seriesUrl = 'http://58866a241fe9aa12004b7b5c.mockapi.io/seriesId';
    return Axios
        .get(seriesUrl)
        .catch(error => {
            throw(error);
        });
}