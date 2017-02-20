import { FETCH_SERIES_SUCCESS, FETCH_SERIES_BY_ID_SUCCESS, FETCH_HOME_COMICS_SUCCESS, SEARCH_SUCCESS, FOLLOW_SERIES_SUCCESS } from '../actions/constants';

export const seriesReducer = (state = [], action) => {
    switch (action.type) {
        case FETCH_SERIES_SUCCESS:
            return action.series;
        case SEARCH_SUCCESS:
            return action.series;
        case FOLLOW_SERIES_SUCCESS:
            for (let i in state) {
                let item = state[i];
                if (item.id == action.id) {
                    item.following = !item.following;
                    break;
                }
            }
            return [...state];
        default:
            return state;
    }
};
const initialDetailState = { "comicCount": 0, "read": 0, "comics": [], "id": 0, "url": "", "title": "", "thumbnail": "", "description": null, "following": true };
export const seriesDetailsReducer = (state = initialDetailState, action) => {
    switch (action.type) {
        case FETCH_SERIES_BY_ID_SUCCESS:
            return action.seriesDetails;
        default:
            return state;
    }
};

export const homeComicsReducer = (state = [], action) => {
    switch (action.type) {
        case FETCH_HOME_COMICS_SUCCESS:
            return action.homeComics;
        default:
            return state;
    }
};
