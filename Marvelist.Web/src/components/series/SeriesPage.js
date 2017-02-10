import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Card from '../card/Card';
import { fetchSeries, folllowSeries } from '../../actions/seriesActions';

class Series extends React.Component {
  constructor(props) {
    super(props);
    debugger;
    this.hasData = false;
  }
  componentWillMount() {
    if(!this.props.params.text)
      this.props.fetch();
  }
  componentWillReceiveProps(nextProps) {
    if (this.props.series !== nextProps.series) {
      this.hasData = true;
    }
  }
  render() {
  let {follow} = this.props;
    const seriesList = this.hasData ? this.props.series.map((b, i) => <Card key={i} follow={follow} data={b} seriesLink />) : "";
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