import {FETCH_SERIES_SUCCESS, FETCH_SERIES_BY_ID_SUCCESS} from '../actions/constants';

export const seriesReducer = (state = {}, action) => {
    switch (action.type) {
        case FETCH_SERIES_SUCCESS:
            return {...state,series: action.series};
        default:
            return state;
    }
};

export const seriesDetailsReducer = (state = {}, action) => {
    switch (action.type) {
        case FETCH_SERIES_BY_ID_SUCCESS:
            return {...state, seriesDetails: action.seriesDetails};
        default:
            return state;
    }
};
