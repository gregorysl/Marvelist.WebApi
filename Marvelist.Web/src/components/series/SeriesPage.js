import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Card from '../card/Card';
import TextHeader from './TextHeader';
import { fetchSeries, folllowSeries, search } from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';
import { Switch, Icon } from 'antd';

class Series extends React.Component {
  constructor(props) {
    super(props);
    this.mapData = this.mapData.bind(this);
    this.state = { showFollowed: true };
    this.data = "";
  }

  componentWillMount() {
    this.getData(this.props);
  }

  componentWillReceiveProps(nextProps) {
    if (this.props.params != nextProps.params) {
      this.getData(nextProps);
    }
    if (this.props.series !== nextProps.series) {
      let {follow} = nextProps;
      this.data = this.mapData(nextProps);
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
    this.data = this.mapData(this.props);
  }
  mapData(props) {
    const series = this.state.showFollowed ? props.series : props.series.filter(x => x.following == false);
    return series.map((b, i) => <Card key={i} follow={props.follow} data={b} link={PLACE.SERIES} />);
  }
  render() {
    return (
      <div className="row cards">
        <TextHeader text={this.props.params.text} />
         <Switch checkedChildren={"Show following series"} unCheckedChildren={"Hide following series"} />
        <div className="paper-toggle">
          <input type="checkbox" id="toggle" name="toggle" onChange={this.filterBoxChange} checked={this.state.showFollowed} />
          <label htmlFor="toggle">Show following series</label>
        </div>
        {this.data}
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