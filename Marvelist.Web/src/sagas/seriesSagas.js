import {take, call, put, fork, race} from 'redux-saga/effects';
import {browserHistory} from 'react-router';
import Axios from 'axios';
import auth from '../auth';
import {FETCH_SERIES_BY_ID, FETCH_SERIES, FETCH_SERIES_SUCCESS, FETCH_SERIES_BY_ID_SUCCESS} from '../actions/constants';

const apiUrl = "http://localhost/Marvelist/api/Series/y2014";

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

export function * fetchSeriesByIdFlow() {
    for (;;) {
        const {id} = yield take(FETCH_SERIES_BY_ID);
        try {
            let response = yield call(fetchSeriesById, id);
            yield put({type: FETCH_SERIES_BY_ID_SUCCESS, seriesDetails: response.data});
            return response;
        } catch (error) {
            let a = 1;
        }
    }
}

function fetchSeries() {
    let head = {
            'headers': {
                "Content-Type": "application/x-www-form-urlencoded",
                'Authorization': 'Bearer ' + localStorage.getItem('access_token')
            }
        };
    return Axios
        .get(apiUrl,head)
        .catch(error => {
            throw(error);
        });
}
function fetchSeriesById(id) {
    const seriesUrl = "http://localhost/Marvelist/api/Series/" + id;
    let head = {
            'headers': {
                "Content-Type": "application/x-www-form-urlencoded",
                'Authorization': 'Bearer ' + localStorage.getItem('access_token')
            }
        };
    return Axios.get(seriesUrl, head).catch(error => {
        throw(error);
    });
}