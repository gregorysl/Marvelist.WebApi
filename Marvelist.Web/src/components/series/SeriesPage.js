import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import SeriesCard from '../card/SeriesCard.js';
import { fetchSeries } from '../../actions/seriesActions';

class Series extends React.Component {
  constructor(props) {
    super(props);
    this.hasData = false;
  }
  componentWillMount() {
    this.props.fetch();
  }
  componentWillReceiveProps(nextProps) {
    if (this.props.series !== nextProps.series) {
      this.hasData = true;
    }
  }
  render() {
    let seriesList = this.hasData ? this.props.series.map((b, i) => <SeriesCard key={i} series={b} />) : "";
    return (
      <div className="row cards">
        <h3>Series</h3>
        {seriesList}
      </div>
    );
  }
}

const mapStateToProps = (state, ownProps) => {
  return { series: state.series };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetch: () => dispatch(fetchSeries())
  };
};

Series.propTypes = {
  series: PropTypes.array.isRequired,
  fetch: PropTypes.func.isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(Series);