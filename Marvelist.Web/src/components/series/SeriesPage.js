import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router';
import * as bookActions from '../../actions/bookActions';

class Series extends React.Component{
  constructor(props){
    super(props);
  }

  submitBook(input){
    this.props.createBook(input);
  }

 
  render(){
    let titleInput;
    return(
      <div className="row">
        <div className="col-md-6">
          <h3>Series</h3>
          <table className="table">
            <thead>
              <th>
                <td>Title</td>
                <td></td>
              </th>
            </thead>
            <tbody>
            {this.props.series.map((b, i) => {
              return(
                <tr key={i}>
                  <td>{b.Series.Title}</td>
                  <td><Link to={`/books/${b.id}`}>View</Link></td>
                </tr>
              )
            })}
            </tbody>
          </table>
        </div>
        <div className="col-md-6">
          <h3>New Book</h3>
        </div>
      </div>
    )
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    series: state.series
  };
};
const mapDispatchToProps = (dispatch) => {
  return {
    createBook: book => dispatch(bookActions.createBook(book))//change
  };
};


export default connect(mapStateToProps, mapDispatchToProps)(Series);