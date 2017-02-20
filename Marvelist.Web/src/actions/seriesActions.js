import { FETCH_SERIES, FETCH_SERIES_BY_ID, FOLLOW_SERIES, FOLLOW_COMIC, FETCH_HOME_COMICS, SEARCH, READ_ALL_COMIC } from '../actions/constants';

export const fetchSeries = (url) => {
  return { type: FETCH_SERIES, url };
};

export const fetchHome = () => {
  return { type: FETCH_HOME_COMICS };
};

export const fetchSeriesById = (id) => {
  return { type: FETCH_SERIES_BY_ID, id };
};

export const folllowSeries = (id, detailPage) => {
  return { type: FOLLOW_SERIES, id, detailPage };
};

export const folllowComic = (id, home, seriesId) => {
  return { type: FOLLOW_COMIC, id, home, seriesId };
};

export const readAllComic = (seriesId) => {
  return { type: READ_ALL_COMIC, seriesId };
};

export const search = (text) => {
  return { type: SEARCH, text };
};