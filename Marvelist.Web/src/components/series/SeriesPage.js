import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import Card from '../card/Card';
import TextHeader from './TextHeader';
import * as actions from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';
import { Switch, Row } from 'antd';
import { browserHistory } from "react-router";
import Pager from "../common/Pager";

class Series extends React.Component {
  constructor(props) {
    super(props);
    this.mapData = this.mapData.bind(this);
    this.filterBoxChange = this.filterBoxChange.bind(this);
    this.onChangePage = this.onChangePage.bind(this);
    this.data = "";
  }

  componentWillMount() {
    this.getData(this.props);
  }

  componentWillReceiveProps(nextProps) {
    if (this.props.location.query != nextProps.location.query) {
      this.getData(nextProps);
    }
    else if (this.props.params != nextProps.params) {
      this.getData(nextProps);
    }
    this.data = this.mapData(nextProps);
  }

  getData(props) {
    let pageId = 0;
    if (props.location.query.page) {
      pageId = props.location.query.page - 1;
    }
    if (props.route.path === "/dashboard" || props.route.path === "/series") {
      props.fetch(props.route.path, pageId);
    }
    else if (props.params.year) {
      props.showYear(props.params.year, pageId);
    }
    else if (props.params.text) {
      props.search(props.params.text, pageId);
    }
  }

  filterBoxChange(checked) {
    this.props.followedFilter(!this.props.filters.showFollowed);
    this.data = this.mapData(this.props, checked);
  }

  mapData(props) {
    const dashboard = props.route.path === "/dashboard";
    const series = props.filters.showFollowed ? props.series : props.series.filter(x => !x.following);
    return series.map((b, i) => <Card key={i} follow={props.follow} data={b} place={PLACE.SERIES} dashboard={dashboard} />);
  }

  onChangePage(page) {
    let url = this.props.location.pathname + '?page=' + page;
    browserHistory.push(url);
  }

  render() {
    return (
      <div>
        <Row>
          <TextHeader text={this.props.params.text} />
          <p><Switch checkedChildren={"Show"} unCheckedChildren={"Hide"} onChange={this.filterBoxChange} defaultChecked /> following series </p>
          <Pager pageData={this.props.pageData} onChangePage={this.onChangePage} />
        </Row>
        <Row>
          {this.data}
        </Row>
        <Row>
          <Pager pageData={this.props.pageData} onChangePage={this.onChangePage} />
        </Row>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    filters: state.series.filters,
    series: state.series.series,
    pageData: state.series.pageData
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    followedFilter: (show) => dispatch(actions.setFollowedFilter(show)),
    showYear: (year, page) => dispatch(actions.fetchSeriesByYear(year, page)),
    fetch: (text, page) => dispatch(actions.fetchSeries(text, page)),
    search: (text, page) => dispatch(actions.search(text, page)),
    follow: (id) => dispatch(actions.folllowSeries(id))
  };
};

Series.propTypes = {
  fetch: PropTypes.func.isRequired,
  follow: PropTypes.func.isRequired,
  search: PropTypes.func.isRequired,
  followedFilter: PropTypes.func.isRequired,
  series: PropTypes.array,
  pageData: PropTypes.object,
  filters: PropTypes.object,
  params: PropTypes.shape({ text: PropTypes.string }).isRequired,
  route: PropTypes.shape({ path: PropTypes.string }).isRequired,
  location: React.PropTypes.object
};

export default connect(mapStateToProps, mapDispatchToProps)(Series);