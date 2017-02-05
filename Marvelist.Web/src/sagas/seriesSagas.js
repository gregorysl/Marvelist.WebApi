import { take, call, put, fork, race } from 'redux-saga/effects';
import { browserHistory } from 'react-router';
import Axios from 'axios';
import auth from '../auth';
import { FETCH_SERIES_BY_ID, FETCH_SERIES, FETCH_SERIES_SUCCESS, FETCH_SERIES_BY_ID_SUCCESS, FOLLOW_SERIES, FOLLOW_COMIC } from '../actions/constants';

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

export function* followComicFlow() {
    for (; ;) {
        const {id} = yield take(FOLLOW_COMIC);
        try {
            let response = yield call(followComic, id);
            //yield put({type: FETCH_SERIES_BY_ID_SUCCESS, seriesDetails: response.data});
            return response;
        } catch (error) {
            let a = 1;
        }
    }
}

function followComic(id) {
    const url = apiUrl + "FollowC/" + id;
    return post(url, id);
}
function followSeries(id) {
    const url = apiUrl + "FollowS/" + id;
    return post(url, id);
}
function fetchSeries(param) {
    const url = apiUrl + param;
    return get(url);
}
function fetchSeriesById(id) {
    const url = apiUrl + "Series/" + id;
    return get(url);
}

function post(url, data) {
    let head = getHeaders();
    return Axios
        .post(url, data, head)
        .catch(error => {
            throw (error);
        });
}
function get(url, data) {
    let head = getHeaders();
    return Axios
        .get(url, head)
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