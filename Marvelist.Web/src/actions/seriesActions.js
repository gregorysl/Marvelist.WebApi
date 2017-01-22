
import Axios from 'axios';

const apiUrl = "http://587f7cab402f50120072c974.mockapi.io/series";

export const fetchSeriesSuccess = (series) => {
  return {
    type: 'FETCH_SERIES_SUCCESS',
    series
  };
};
export const fetchSeries = () => {
  return (dispatch) => {
    return Axios.get(apiUrl)
      .then(response => {
        dispatch(fetchSeriesSuccess(response.data));
      })
      .catch(error => {
        throw(error);
      });
  };
};

export const fetchSeriesByIdSuccess = (series) => {
  return {
    type: 'FETCH_SERIES_BY_ID_SUCCESS',
    series
  };
};
export const fetchSeriesById = (seriesId) => {
  return (dispatch) => {
    return Axios.get(apiUrl + '/' +seriesId)
      .then(response => {
        dispatch(fetchSeriesByIdSuccess(response.data));
      })
      .catch(error => {
        throw(error);
      });
  };
};