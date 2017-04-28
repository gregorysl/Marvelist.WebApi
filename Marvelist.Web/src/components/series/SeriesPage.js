import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Card from '../card/Card';
import TextHeader from './TextHeader';
import { fetchSeries, folllowSeries, search } from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';
import { Switch, Pagination } from 'antd';
import { browserHistory } from "react-router";

class Series extends React.Component {
  constructor(props) {
    super(props);
    this.mapData = this.mapData.bind(this);
    this.filterBoxChange = this.filterBoxChange.bind(this);
    this.onChangePage = this.onChangePage.bind(this);
    //todo move to store
    this.state = { showFollowed: true };
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
    this.data = this.mapData(nextProps, this.state.showFollowed);
  }

  getData(props) {
    let pageId = 0;
    if (props.location.query.page) {
      pageId = props.location.query.page - 1;
    }
    if (props.route.path === "/dashboard" || props.route.path === "/series") {
      props.fetch(props.route.path, pageId);
    }
    else if (props.params.text) {
      props.search(props.params.text, pageId);
    }
  }

  filterBoxChange(checked) {
    this.setState({ showFollowed: checked });
    this.data = this.mapData(this.props, checked);
  }

  mapData(props, showFollowed) {
    const dashboard = props.route.path === "/dashboard";
    const series = showFollowed ? props.series : props.series.filter(x => !x.following);
    return series.map((b, i) => <Card key={i} follow={props.follow} data={b} place={PLACE.SERIES} dashboard={dashboard} />);
  }

  onChangePage(page) {
    let url = this.props.location.pathname + '?page=' + page;
    browserHistory.push(url);
  }

  render() {
    let { pageData } = this.props;
    let page = pageData.page + 1;
    return (
      <div>
        <div className="row">
          <TextHeader text={this.props.params.text} />
          <p><Switch checkedChildren={"Show"} unCheckedChildren={"Hide"} onChange={this.filterBoxChange} defaultChecked /> following series </p>
          <Pagination current={page} total={pageData.count} pageSize={pageData.pageSize} onChange={this.onChangePage} />
        </div>
        <div className="row cards">
          {this.data}
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    series: state.series.series,
    pageData: state.series.pageData
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetch: (text, page) => dispatch(fetchSeries(text, page)),
    search: (text, page) => dispatch(search(text, page)),
    follow: (id) => dispatch(folllowSeries(id))
  };
};

Series.propTypes = {
  fetch: PropTypes.func.isRequired,
  follow: PropTypes.func.isRequired,
  search: PropTypes.func.isRequired,
  series: PropTypes.array,
  pageData: PropTypes.object,
  params: PropTypes.shape({ text: PropTypes.string }).isRequired,
  route: PropTypes.shape({ path: PropTypes.string }).isRequired,
  location: React.PropTypes.object
};

export default connect(mapStateToProps, mapDispatchToProps)(Series);