import * as actionTypes from './actionTypes';
import Axios from 'axios';

const apiUrl = "http://587e8379258d641200033cab.mockapi.io/books";

export const fetchBooksSuccess = (books) => {
  return {
    type: actionTypes.FETCH_BOOKS_SUCCESS,
    books
  };
};
export const fetchBooks = () => {
  return (dispatch) => {
    return Axios.get(apiUrl)
      .then(response => {
        dispatch(fetchBooksSuccess(response.data));
      })
      .catch(error => {
        throw(error);
      });
  };
};

export const createBookSuccess = (book) => {
  return {
    type: actionTypes.CREATE_BOOK_SUCCESS,
    book: book
  };
};

export const createBook = (book) => {
  return (dispatch) => {
    return Axios.post(apiUrl, book)
      .then(response => {
        dispatch(createBookSuccess(response.data));
      })
      .catch(error => {
        throw(error);
      });
  };
};

export const fetchBookByIdSuccess = (book) => {
  return {
    type: actionTypes.FETCH_BOOK_BY_ID_SUCCESS,
    book
  };
};
export const fetchBookById = (bookId) => {
  return (dispatch) => {
    return Axios.get(apiUrl + '/' +bookId)
      .then(response => {
        dispatch(fetchBookByIdSuccess(response.data));
      })
      .catch(error => {
        throw(error);
      });
  };
};

// Sync add to cart
export const addToCartSuccess = (item) => {
  return {
    type: 'ADD_TO_CART_SUCCESS',
    item
  }
};
// Async add to cart
export const addToCart = (item) => {
  return (dispatch) => {
    return Axios.post('http://57c64baac1fc8711008f2a82.mockapi.io/Cart', item)
      .then(response => {
        dispatch(addToCartSuccess(response.data))
      })
      .catch(error => {
        throw(error);
      });
  };
};
// Sync load cart
export const fetchCartSuccess = (items) => {
  return {
    type: 'FETCH_CART_SUCCESS',
    items
  }
};
// Async load cart
export const fetchCart = () => {
  return (dispatch) => {
    return Axios.get('http://57c64baac1fc8711008f2a82.mockapi.io/Cart')
      .then(response => {
        dispatch(fetchCartSuccess(response.data))
      })
      .catch(error => {
        throw(error);
      });
  };
};