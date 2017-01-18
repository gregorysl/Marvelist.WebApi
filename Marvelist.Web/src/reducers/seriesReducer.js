export const seriesReducer = (state = [], action) => {
    switch (action.type) {
        case 'FETCH_SERIES_SUCCESS':
            return action.series;
        case 'CREATE_BOOK_SUCCESS':
            return [
                ...state,
                Object.assign({}, action.series)
            ];
        default:
            return state;
    }
};