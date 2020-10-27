import React from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import Card from "../card/Card";
import TextHeader from "./TextHeader";
import * as actions from "../../actions/seriesActions";
import { PLACE } from "../../actions/constants";
import { Switch, Row } from "antd";
import history from "../../history";
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
    if (this.props.location !== nextProps.location) {
      this.getData(nextProps);
    } else if (this.props.match.params.text !== nextProps.match.params.text) {
      this.getData(nextProps);
    }
    this.data = this.mapData(nextProps);
  }

  getData(props) {
    let pageId = 0;
    let queryParams = new URLSearchParams(props.location.search);
    let page = queryParams.get("page");
    let year = props.match.params.year;
    let text = props.match.params.text;
    if (page) {
      pageId = page - 1;
    }
    let path = props.location.pathname;
    if (path === "/dashboard" || path === "/series") {
      props.fetch(path, pageId);
    } else if (year) {
      props.showYear(year, pageId);
    } else if (text) {
      props.search(text, pageId);
    }
  }

  filterBoxChange(checked) {
    this.props.followedFilter(!this.props.filters.showFollowed);
    this.data = this.mapData(this.props, checked);
  }

  mapData(props) {
    const dashboard = props.location.pathname === "/dashboard";
    const series = props.filters.showFollowed
      ? props.series
      : props.series.filter((x) => !x.following);
    return series.map((b, i) => (
      <Card
        key={i}
        follow={props.follow}
        data={b}
        place={PLACE.SERIES}
        dashboard={dashboard}
      />
    ));
  }

  getHeaderText() {
    let queryParams = new URLSearchParams(this.props.location.search);
    let text = queryParams.get("text");
    return text;
  }

  onChangePage(page) {
    let url = this.props.location.pathname + "?page=" + page;
    history.push(url);
  }

  render() {
    return (
      <div>
        <Row>
          <TextHeader text={this.getHeaderText()} />
          <p>
            <Switch
              checkedChildren={"Show"}
              unCheckedChildren={"Hide"}
              onChange={this.filterBoxChange}
              defaultChecked
            />{" "}
            following series{" "}
          </p>
          <Pager
            pageData={this.props.pageData}
            onChangePage={this.onChangePage}
          />
        </Row>
        <Row>{this.data}</Row>
        <Row>
          <Pager
            pageData={this.props.pageData}
            onChangePage={this.onChangePage}
          />
        </Row>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    filters: state.series.filters,
    series: state.series.series,
    pageData: state.series.pageData,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    followedFilter: (show) => dispatch(actions.setFollowedFilter(show)),
    showYear: (year, page) => dispatch(actions.fetchSeriesByYear(year, page)),
    fetch: (text, page) => dispatch(actions.fetchSeries(text, page)),
    search: (text, page) => dispatch(actions.search(text, page)),
    follow: (id) => dispatch(actions.folllowSeries(id)),
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
  location: PropTypes.object,
  match: PropTypes.shape({
    params: PropTypes.shape({
      text: PropTypes.node,
    }).isRequired,
  }).isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(Series);
