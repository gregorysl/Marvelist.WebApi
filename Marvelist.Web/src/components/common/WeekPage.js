import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import moment from 'moment';
import Card from '../card/Card';
import { week, folllowComic } from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';

class WeekPage extends React.Component {
  constructor(props) {
    super(props);
    this.data = "";
  }
  componentWillMount() {
    this.getData(this.props);
    this.mapData(this.props);
  }
  getData(props){
    debugger;
    const weekNum = !props.match.params.week ? moment().week() : props.match.params.week;
    
    this.props.fetch(weekNum);
  }
  componentWillReceiveProps(nextProps) {
    if (this.props.match.params.week != nextProps.match.params.week) {
      this.getData(nextProps);
    }
    if (this.props.data !== nextProps.data) {
      this.mapData(nextProps);
    }
  }
  mapData(props) {
    let { follow } = props;
    this.data = props.data.map((b, i) => <Card key={i} follow={follow} data={b} place={PLACE.HOME} />);
  }

  render() {
    return (
      <div className="row cards">
        {this.data}
      </div>
    );
  }
}
const mapStateToProps = (state) => {
  return { data: state.week, user: state.user };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetch: (weekName) => dispatch(week(weekName)),
    follow: (id) => dispatch(folllowComic(id, true))
  };
};

WeekPage.propTypes = {
  user: PropTypes.object.isRequired,
  fetch: PropTypes.func.isRequired,
  home: PropTypes.array,
  follow: PropTypes.func.isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(WeekPage);
