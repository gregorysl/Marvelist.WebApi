import {FETCH_SERIES_SUCCESS, FETCH_SERIES_BY_ID_SUCCESS} from '../actions/constants';

export const seriesReducer = (state = [], action) => {
    switch (action.type) {
        case FETCH_SERIES_SUCCESS:
            return action.series;
        default:
            return state;
    }
};

export const seriesDetailsReducer = (state = {}, action) => {
    switch (action.type) {
        case FETCH_SERIES_BY_ID_SUCCESS:
            return action.seriesDetails;
        default:
            return state;
    }
};
