import {FETCH_SERIES, FETCH_SERIES_BY_ID, FOLLOW_SERIES} from '../actions/constants';

export const fetchSeries = (series) => {
  return {type: FETCH_SERIES, series};
};

export const fetchSeriesById = (id) => {
  return {type: FETCH_SERIES_BY_ID, id};
};

export const folllowSeries = (id) => {
  return {type: FOLLOW_SERIES, id};
};