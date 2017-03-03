import * as consts from '../actions/constants';

export const seriesReducer = (state = [], action) => {
    switch (action.type) {
        case consts.FETCH_SERIES_SUCCESS:
            return action.series.map(x => ({ ...x, loading: false }));
        case consts.SEARCH_SUCCESS:
            return action.series.map(x => ({ ...x, loading: false }));
        case consts.FOLLOW_SERIES: {
            if (!action.detailPage) {
                let idx = state.findIndex(x => x.id == action.id);
                let item = state[idx];
                item.loading = true;
            }
            return [...state];
        }
        case consts.FOLLOW_SERIES_SUCCESS: {
            let idx = state.findIndex(x => x.id == action.id);
            let item = state[idx];
            item.following = !item.following;
            item.loading = false;
            return [...state];
        }
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
                let item = state.comics[idx];
                item.loading = true;
            }
            return { ...state };
        }
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
                let item = state[idx];
                item.loading = true;
            }
            return [...state];
        }

        default:
            return state;
    }
};
