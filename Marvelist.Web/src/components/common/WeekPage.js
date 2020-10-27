import React from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import Card from "../card/Card";
import { week, folllowComic } from "../../actions/seriesActions";
import { PLACE } from "../../actions/constants";
import { Col, Row, Button, Icon } from "antd";

const moment = require("moment");
const dateFormat = "YYYY[W]WW";
class WeekPage extends React.Component {
  constructor(props) {
    super(props);
    this.data = "";
    this._previous = this._previous.bind(this);
    this._next = this._next.bind(this);
  }
  componentWillMount() {
    const week = this.props.match.params.week;
    if (!week) {
      this.props.history.push(`week/${moment().year()}W${moment().week()}`);
    }
    this.getData(week);
  }
  componentWillReceiveProps(nextProps) {
    const nextPropsWeek = nextProps.match.params.week;
    if (this.props.match.params.week !== nextPropsWeek) {
      this.getData(nextPropsWeek);
    }
    if (!nextProps.loading) {
      if (this.props.match.params.week !== nextPropsWeek) {
        this.getData(nextPropsWeek);
      }
      if (this.props.data !== nextProps.data) {
        this.mapData(nextProps);
      }
    }
  }
  _previous() {
    this.props.history.push(this.state.previous);
  }
  _next() {
    this.props.history.push(this.state.next);
  }
  getData(week) {
    if (!week) return;

    const previous = moment(week, dateFormat)
      .add(-1, "week")
      .format(dateFormat);
    const next = moment(week, dateFormat).add(1, "week").format(dateFormat);
    const weekTillApiChanged = moment(week, dateFormat)
      .add(1, "week")
      .format("WW-YYYY");
    this.setState({ week, previous, next, weekTillApiChanged });

    this.props.fetch(weekTillApiChanged);
  }

  mapData(props) {
    let { follow } = props;
    this.data = props.data.map((b, i) => (
      <Card
        key={i}
        follow={follow}
        data={b}
        place={PLACE.WEEK}
        week={this.state.weekTillApiChanged}
      />
    ));
  }

  render() {
    return (
      <div>
        <Row className="week-header">
          <Col span={4}>
            <Button type="primary" onClick={this._previous}>
              <Icon type="left" />
              Backward
            </Button>
          </Col>
          <Col span={16}>
            <h1>{this.props.match.params.week}</h1>
          </Col>
          <Col span={4}>
            <Button type="primary" onClick={this._next}>
              Forward
              <Icon type="right" />
            </Button>
          </Col>
        </Row>
        <div className="row cards">{this.data}</div>
      </div>
    );
  }
}
const mapStateToProps = (state) => {
  return {
    data: state.week.comics,
    loading: state.week.loading,
    user: state.user,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetch: (weekName) => dispatch(week(weekName)),
    follow: (id, seriesId, week) =>
      dispatch(folllowComic(id, PLACE.WEEK, seriesId, week)),
  };
};

WeekPage.propTypes = {
  user: PropTypes.object.isRequired,
  fetch: PropTypes.func.isRequired,
  home: PropTypes.array,
  data: PropTypes.array,
  follow: PropTypes.func.isRequired,
  match: PropTypes.shape({
    params: PropTypes.shape({
      week: PropTypes.node,
    }).isRequired,
  }).isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(WeekPage);
