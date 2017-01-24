
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

export const fetchSeriesByIdSuccess = (seriesDetails) => {
  return {
    type: 'FETCH_SERIES_BY_ID_SUCCESS',
    seriesDetails
  };
};
export const fetchSeriesById = (seriesId) => {
  const seriesUrl = 'http://58866a241fe9aa12004b7b5c.mockapi.io/seriesId';
  return (dispatch) => {
    return Axios.get(seriesUrl)
      .then(response => {
        dispatch(fetchSeriesByIdSuccess(response.data[0]));
      })
      .catch(error => {
        throw(error);
      });
  };
};