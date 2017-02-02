import { take, call, put, fork, race } from 'redux-saga/effects';
import { browserHistory } from 'react-router';
import Axios from 'axios';
import auth from '../auth';
import { FETCH_SERIES_BY_ID, FETCH_SERIES, FETCH_SERIES_SUCCESS, FETCH_SERIES_BY_ID_SUCCESS, FOLLOW_SERIES } from '../actions/constants';

const apiUrl = "http://localhost/Marvelist/api/";

export function* fetchSeriesFlow() {
    for (; ;) {
        yield take(FETCH_SERIES);
        try {
            let response = yield call(fetchSeries, "Series/y2014");
            yield put({ type: FETCH_SERIES_SUCCESS, series: response.data });
            return response;
        } catch (error) {
            let a = 1;
        }
    }
}

export function* fetchSeriesByIdFlow() {
    for (; ;) {
        const {id} = yield take(FETCH_SERIES_BY_ID);
        try {
            let response = yield call(fetchSeriesById, id);
            yield put({ type: FETCH_SERIES_BY_ID_SUCCESS, seriesDetails: response.data });
            return response;
        } catch (error) {
            let a = 1;
        }
    }
}

export function* followSeriesFlow() {
    for (; ;) {
        const {id} = yield take(FOLLOW_SERIES);
        try {
            let response = yield call(followSeries, id);
            debugger;
            //yield put({type: FETCH_SERIES_BY_ID_SUCCESS, seriesDetails: response.data});
            return response;
        } catch (error) {
            let a = 1;
        }
    }
}

function followSeries(id) {
    let head = getHeaders();
    const url = apiUrl + "FollowS/" + id;
    return Axios
        .post(url, id, head)
        .catch(error => {
            throw (error);
        });
}
function fetchSeries(url) {
    let head = getHeaders();
    return Axios
        .get(apiUrl + url, head)
        .catch(error => {
            throw (error);
        });
}
function fetchSeriesById(id) {
    const seriesUrl = apiUrl + "Series/" + id;
    let head = getHeaders();
    return Axios
        .get(seriesUrl, head)
        .catch(error => {
            throw (error);
        });
}

function getHeaders() {
    return auth.expired()
        ? ""
        : {
            'headers': {
                "Content-Type": "application/x-www-form-urlencoded",
                'Authorization': 'Bearer ' + localStorage.getItem('access_token')
            }
        };
}