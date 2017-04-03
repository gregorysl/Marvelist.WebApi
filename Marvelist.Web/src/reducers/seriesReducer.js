import * as consts from '../actions/constants';
import update from 'immutability-helper';

const initialStateSeries = { pageData: { count: 0, pageSize: 0, page: 0 }, series: [] };
export const seriesReducer = (state = initialStateSeries, action) => {
    switch (action.type) {
        case consts.FETCH_SERIES_SUCCESS:
            return { ...state, pageData: action.data.pageData, series: action.data.series.map(x => ({ ...x, loading: false })) };
        case consts.SEARCH_SUCCESS:
            return { ...state, pageData: action.data.pageData, series: action.data.series.map(x => ({ ...x, loading: false })) };
        case consts.FOLLOW_SERIES: {
            if (!action.detailPage) {
                let idx = state.series.findIndex(x => x.id == action.id);
                const newData = update(state, { series: { [idx]: { loading: { $set: true } } } });
                return { ...newData };
            }
            return { ...state };
        }
        case consts.FOLLOW_SERIES_SUCCESS: {
            let idx = state.series.findIndex(x => x.id == action.id);
            const newData = update(state, { series: { [idx]: { loading: { $set: false }, following: { $apply: function (x) { return !x; } } } } });
            return { ...newData };
        }
        case consts.LOGOUT:
            return { ...initialStateSeries };
        default:
            return state;
    }
};
const initialDetailState = { "comicCount": 0, "read": 0, "comics": [], "id": 0, "url": "", "title": "", "thumbnail": "", "description": null, "following": true };
export const seriesDetailsReducer = (state = initialDetailState, action) => {
    switch (action.type) {
        case consts.FETCH_SERIES_BY_ID_SUCCESS: {
            let comics = action.seriesDetails.comics.map(x => ({ ...x, loading: false }));
            action.seriesDetails.comics = comics;
            return action.seriesDetails;

        }
        case consts.FOLLOW_COMIC: {
            if (!action.home) {
                let idx = state.comics.findIndex(x => x.id == action.id);
                const newData = update(state, { comics: { [idx]: { loading: { $set: true } } } });
                return [...newData];
            }
            return state;
        }
        case consts.LOGOUT:
            return { ...initialDetailState };
        default:
            return state;
    }
};

export const homeComicsReducer = (state = [], action) => {
    switch (action.type) {
        case consts.FETCH_HOME_COMICS_SUCCESS:
            return action.homeComics.map(x => ({ ...x, loading: false }));
        case consts.FOLLOW_COMIC: {
            if (action.home) {
                let idx = state.findIndex(x => x.id == action.id);
                const newData = update(state, { [idx]: { loading: { $set: true } } });
                return [...newData];
            }
            return state;
        }
        case consts.LOGOUT:
            return [];
        default:
            return state;
    }
};
