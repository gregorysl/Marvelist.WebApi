import { FETCH_SERIES, FETCH_SERIES_BY_ID, FOLLOW_SERIES, FOLLOW_COMIC, FETCH_HOME_COMICS } from '../actions/constants';

export const fetchSeries = (series) => {
  return { type: FETCH_SERIES, series };
};
export const fetchHome = () => {
  return { type: FETCH_HOME_COMICS };
};

export const fetchSeriesById = (id) => {
  return { type: FETCH_SERIES_BY_ID, id };
};

export const folllowSeries = (id) => {
  return { type: FOLLOW_SERIES, id };
};
export const folllowComic = (id, home) => {
  return { type: FOLLOW_COMIC, id, home };
};