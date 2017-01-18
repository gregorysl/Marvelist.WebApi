import React, {PropTypes} from 'react';

const BookDetails = ({book}) => {
    return (
      <div className="media">
        <div className="media-left">
          <a href="#">
            <img className="media-object" src="http://placehold.it/200/450" alt="Placehold" />
          </a>
        </div>
        <div className="media-body">
          <h4 className="media-heading">{book.title}</h4>
          <ul>
            <li><stron>Author: </stron> {book.author}</li>
            <li><stron>Price: </stron> ${book.price}</li>
            <li><stron>Year: </stron> {new Date(book.year).getFullYear()}</li>
            <br/>
          </ul>
        </div>
      </div>
    );
};

export default BookDetails;