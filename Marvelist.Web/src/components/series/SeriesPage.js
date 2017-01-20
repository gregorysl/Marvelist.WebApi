import React from 'react';
import {connect} from 'react-redux';
import {Link} from 'react-router';
import SeriesCard from '../card/SeriesCard.js';
import * as bookActions from '../../actions/bookActions';

class Series extends React.Component {
  constructor(props) {
    super(props);
  }

  submitBook(input) {
    this
      .props
      .createBook(input);
  }

  render() {
    let titleInput;
    return (
      <div className="row">
        <h3>Series</h3>
        {this
          .props
          .series
          .map((b, i) => {
            return (<SeriesCard key={i} series={b}/>);
          })}

      </div>
    )
  }
}

const mapStateToProps = (state, ownProps) => {
  return {series: state.series};
};
const mapDispatchToProps = (dispatch) => {
  return {
    createBook: book => dispatch(bookActions.createBook(book)) //change
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Series);