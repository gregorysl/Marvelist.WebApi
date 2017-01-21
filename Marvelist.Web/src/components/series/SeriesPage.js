import React, {PropTypes}  from 'react';
import {connect} from 'react-redux';
import SeriesCard from '../card/SeriesCard.js';

class Series extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    let seriesList = this.props.series.map((b, i) => <SeriesCard key={i} series={b}/>);
    return (
      <div className="row series-list">
        <h3>Series</h3>
        {seriesList}
      </div>
    );
  }
}

const mapStateToProps = (state, ownProps) => {
  return {series: state.series};
};

const mapDispatchToProps = (dispatch) => {
  return {};
};

Series.propTypes = {
    series: PropTypes.array.isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(Series);