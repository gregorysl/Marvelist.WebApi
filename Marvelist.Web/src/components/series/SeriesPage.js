import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Card from '../card/Card';
import TextHeader from './TextHeader';
import { fetchSeries, folllowSeries, search } from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';

class Series extends React.Component {
  constructor(props) {
    super(props);
    this.filterBoxChange = this.filterBoxChange.bind(this);
    this.state = { showFollowed: true };
  }

  componentWillMount() {
    this.getData(this.props);
  }


  componentWillReceiveProps(nextProps) {
    if (this.props.params != nextProps.params) {
      this.getData(nextProps);
    }
  }

  getData(props) {
    if (props.route.path === "/dashboard" || props.route.path === "/series") {
      props.fetch(props.route.path);
    }
    else if (props.params.text) {
      props.search(props.params.text);
    }

  }
  filterBoxChange() {
    this.setState({ ...this.state, showFollowed: !this.state.showFollowed });

  }
  getFilteredSeries() {
    return this.state.showFollowed ? this.props.series : this.props.series.filter(x => x.following == false);
  }
  render() {
    let {follow} = this.props;
    const seriesList = this.getFilteredSeries().map((b, i) => <Card key={i} follow={follow} data={b} link={PLACE.SERIES} />);
    return (
      <div className="row cards">
        <TextHeader text={this.props.params.text} />
        <div className="paper-toggle">
          <input type="checkbox" id="toggle" name="toggle" onChange={this.filterBoxChange} checked={this.state.showFollowed} />
          <label htmlFor="toggle">Show following series</label>
        </div>
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
    fetch: (text) => dispatch(fetchSeries(text)),
    search: (text) => dispatch(search(text)),
    follow: (id) => dispatch(folllowSeries(id))
  };
};

Series.propTypes = {
  series: PropTypes.array.isRequired,
  fetch: PropTypes.func.isRequired,
  follow: PropTypes.func.isRequired,
  search: PropTypes.func.isRequired,
  params: PropTypes.shape({ text: PropTypes.string }).isRequired,
  route: PropTypes.shape({ path: PropTypes.string }).isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(Series);