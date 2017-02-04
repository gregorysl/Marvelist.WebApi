import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Card from '../card/Card';
import { fetchSeries, folllowSeries } from '../../actions/seriesActions';

class Series extends React.Component {
  constructor(props) {
    super(props);
    this.hasData = false;
    this.toggleFollow = this.toggleFollow.bind(this);
  }
  componentWillMount() {
    this.props.fetch();
  }
  componentWillReceiveProps(nextProps) {
    if (this.props.series !== nextProps.series) {
      this.hasData = true;
    }
  }
  toggleFollow() {
    this.props.follow(this.props.series.id);
  }
  render() {
    const seriesList = this.hasData ? this.props.series.map((b, i) => <Card key={i} toggleFollow={this.toggleFollow} data={b} seriesLink />) : "";
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
    fetch: () => dispatch(fetchSeries()),
    follow: (id) => dispatch(folllowSeries(id))
  };
};

Series.propTypes = {
  series: PropTypes.array.isRequired,
  fetch: PropTypes.func.isRequired,
  follow: PropTypes.func.isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(Series);