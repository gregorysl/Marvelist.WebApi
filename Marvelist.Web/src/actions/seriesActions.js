import * as consts from '../actions/constants';

export const fetchSeries = (url, page) => {
  return { type: consts.FETCH_SERIES, url, page };
};
export const fetchHome = () => {
  return { type: consts.FETCH_HOME_COMICS };
};

export const fetchSeriesById = (id) => {
  return { type: consts.FETCH_SERIES_BY_ID, id };
};

export const fetchSeriesByYear = (year, page) => {
  return { type: consts.FETCH_SERIES_BY_YEAR, year, page };
};

export const folllowSeries = (id, detailPage) => {
  return { type: consts.FOLLOW_SERIES, id, detailPage };
};

export const folllowComic = (id, place, seriesId) => {
  return { type: consts.FOLLOW_COMIC, id, place, seriesId };
};

export const readAllComic = (seriesId) => {
  return { type: consts.READ_ALL_COMIC, seriesId };
};

export const search = (text, page) => {
  return { type: consts.SEARCH, text, page };
};

export const week = (text) => {
  return { type: consts.WEEK, text };
};

export const setFollowedFilter = (show) => {
  return { type: consts.FILTER_SHOW_FOLLOWED, show };
};
