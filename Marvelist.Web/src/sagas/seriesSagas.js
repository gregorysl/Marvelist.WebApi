import { take, call, put, fork, race } from 'redux-saga/effects';
import { browserHistory } from 'react-router';
import Axios from 'axios';
import auth from '../auth';
import { FETCH_SERIES_BY_ID, FETCH_SERIES, FETCH_SERIES_SUCCESS, FETCH_SERIES_BY_ID_SUCCESS, FOLLOW_SERIES, FOLLOW_COMIC, FETCH_HOME_COMICS, FETCH_HOME_COMICS_SUCCESS } from '../actions/constants';

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
} export function* fetchHomeFlow() {
    for (; ;) {
        yield take(FETCH_HOME_COMICS);
        let response = yield call(fetchSeries, "Comics/");
        yield put({ type: FETCH_HOME_COMICS_SUCCESS, homeComics: response.data });
    }
}

export function* fetchSeriesByIdFlow() {
    for (; ;) {
        const {id} = yield take(FETCH_SERIES_BY_ID);
        const url = apiUrl + "Series/" + id;
        let response = yield call(get, url, id);
        yield put({ type: FETCH_SERIES_BY_ID_SUCCESS, seriesDetails: response.data });
    }
}

export function* followSeriesFlow() {
    for (; ;) {
        const {id} = yield take(FOLLOW_SERIES);
        const url = apiUrl + "FollowS/" + id;
        let response = yield call(post, url, id);
    }
}

export function* followComicFlow() {
    for (; ;) {
        const {id} = yield take(FOLLOW_COMIC);
        const url = apiUrl + "FollowC/" + id;
        yield call(post, url, id);
        let response = yield call(fetchSeries, "Comics/");
        yield put({ type: FETCH_HOME_COMICS_SUCCESS, homeComics: response.data });
    }
}

function fetchSeries(param) {
    const url = apiUrl + param;
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