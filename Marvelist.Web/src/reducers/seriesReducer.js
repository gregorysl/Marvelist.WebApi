import * as consts from '../actions/constants';
import update from 'immutability-helper';

const emptyPageDataState = { pageData: { count: 0, pageSize: 0, page: 0 } };
const loadingCardState = { description: "", "title": "LOADING", "thumbnail": "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available/portrait_uncanny.jpg", "loading": true };
const initialSeriesState = { ...emptyPageDataState, series: [], seriesFiltered: [], filters: { showFollowed: true } };
const loadingSeriesCardState = { ...emptyPageDataState, series: [loadingCardState] };
export const seriesReducer = (state = initialSeriesState, action) => {
    switch (action.type) {
        case consts.FILTER_SHOW_FOLLOWED: {
            const newData = update(state, { filters: { showFollowed: { $set: action.show } } });
            //const newState = update(newData, { series: { $apply: serie => serie.filter(s => s.followed !== id) } });
            return { ...newData, };
        }
        case consts.CARD_LOADING:
            return { ...state, ...loadingSeriesCardState };
        case consts.FETCH_SERIES_SUCCESS:
        case consts.FETCH_SERIES_BY_YEAR_SUCCESS:
        case consts.SEARCH_SUCCESS:
            return { ...state, pageData: action.data.pageData, series: action.data.series.map(x => ({ ...x, loading: false })) };
        case consts.WEEK_SUCCESS:
                return { ...state,  series: action.data.map(x => ({ ...x, loading: false })) };
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
            return { ...initialSeriesState };
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
                return {...newData};
            }
            return state;
        }
        case consts.LOGOUT:
            return { ...initialDetailState };
        default:
            return state;
    }
};


export const homeComicsReducer = (state = [loadingCardState], action) => {
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

export const weekComicsReducer = (state = [loadingCardState], action) => {
    switch (action.type) {
        case consts.WEEK_SUCCESS:
            return action.data.map(x => ({ ...x, loading: false }));
        // case consts.FOLLOW_COMIC: {
        //     if (action.home) {
        //         let idx = state.findIndex(x => x.id == action.id);
        //         const newData = update(state, { [idx]: { loading: { $set: true } } });
        //         return [...newData];
        //     }
        //     return state;
        // }
        default:
            return state;
    }
};
