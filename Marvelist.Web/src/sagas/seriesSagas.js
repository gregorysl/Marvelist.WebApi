import { take, call, put } from 'redux-saga/effects';
import Axios from 'axios';
import auth from '../auth';
import * as consts from '../actions/constants';

const apiUrl = "http://localhost/Marvelist/api/";

export function* fetchSeriesFlow() {
    for (; ;) {
        let { url, page } = yield take(consts.FETCH_SERIES);
        let response = yield call(fetchSeries, url + '?page=' + page);
        yield put({ type: consts.FETCH_SERIES_SUCCESS, data: response.data });
    }
}

export function* fetchHomeFlow() {
    for (; ;) {
        yield take(consts.FETCH_HOME_COMICS);
        let response = yield call(fetchSeries, "Comics/");
        yield put({ type: consts.FETCH_HOME_COMICS_SUCCESS, homeComics: response.data });
    }
}

export function* fetchSeriesByIdFlow() {
    for (; ;) {
        const { id } = yield take(consts.FETCH_SERIES_BY_ID);
        const url = apiUrl + "Series/" + id;
        let response = yield call(get, url, id);
        yield put({ type: consts.FETCH_SERIES_BY_ID_SUCCESS, seriesDetails: response.data });
    }
}

export function* searchFlow() {
    for (; ;) {
        const { text, page } = yield take(consts.SEARCH);
        const url = apiUrl + "Search/" + text + '?page=' + page;
        let response = yield call(get, url);
        yield put({ type: consts.SEARCH_SUCCESS, data: response.data });
    }
}

export function* followSeriesFlow() {
    for (; ;) {
        const { id, detailPage } = yield take(consts.FOLLOW_SERIES);
        const url = apiUrl + "FollowS/" + id;
        yield call(post, url, id);
        if (detailPage) {
            yield put({ type: consts.FETCH_SERIES_BY_ID, id });
        }
        else {
            yield put({ type: consts.FOLLOW_SERIES_SUCCESS, id });
        }
    }
}

export function* followComicFlow() {
    for (; ;) {
        const { id, home, seriesId } = yield take(consts.FOLLOW_COMIC);
        const url = apiUrl + "FollowC/" + id;
        yield call(post, url, id);
        if (home) {
            yield put({ type: consts.FETCH_HOME_COMICS });
        } else {
            yield put({ type: consts.FETCH_SERIES_BY_ID, id: seriesId });

        }
    }
}

export function* readAllComicsFlow() {
    for (; ;) {
        const { seriesId } = yield take(consts.READ_ALL_COMIC);
        const url = apiUrl + "FollowC/all" + seriesId;
        yield call(post, url, seriesId);
        const url2 = apiUrl + "Series/" + seriesId;
        let response = yield call(get, url2, seriesId);
        yield put({ type: consts.FETCH_SERIES_BY_ID_SUCCESS, seriesDetails: response.data });
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
function get(url) {
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