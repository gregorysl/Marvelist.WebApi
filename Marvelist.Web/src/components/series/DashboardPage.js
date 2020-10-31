import React from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import DashboardItem from "../DashboardItem";
import TextHeader from "./TextHeader";
import * as actions from "../../actions/seriesActions";
import { PLACE } from "../../actions/constants";
import { Grid } from "@material-ui/core";

class Dashboard extends React.Component {
  constructor(props) {
    super(props);
    this.mapData = this.mapData.bind(this);
    this.data = "";
  }

  componentWillMount() {
    this.getData(this.props);
  }

  componentWillReceiveProps(nextProps) {
    this.data = this.mapData(nextProps);
  }

  getData(props) {
    props.fetch("/dashboard");
  }

  mapData(props) {
    return props.series.map((b, i) => (
      <DashboardItem
        key={i}
        follow={props.follow}
        data={b}
        place={PLACE.SERIES}
        dashboard
      />
    ));
  }

  render() {
    return (
      <div>
        <TextHeader raw={"Dashboard"} />
        <Grid container spacing={2}>
          {this.data}
        </Grid>
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
    fetch: (text, page) => dispatch(actions.fetchSeries(text, page)),
    search: (text, page) => dispatch(actions.search(text, page)),
    follow: (id) => dispatch(actions.folllowSeries(id)),
  };
};

Dashboard.propTypes = {
  fetch: PropTypes.func.isRequired,
  follow: PropTypes.func.isRequired,
  search: PropTypes.func.isRequired,
  followedFilter: PropTypes.func.isRequired,
  series: PropTypes.array,
  pageData: PropTypes.object,
  filters: PropTypes.object,
  location: PropTypes.object,
};

export default connect(mapStateToProps, mapDispatchToProps)(Dashboard);
