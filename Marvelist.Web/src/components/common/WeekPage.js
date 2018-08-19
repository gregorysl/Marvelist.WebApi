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
    const week = this.props.match.params.week;
    if(!week){
      const asd = `/week/${moment().week()}-${moment().year()}`;
      this.props.history.push(asd);
    }
    this.getData(week);
  }
  componentWillReceiveProps(nextProps) {
    debugger;
    if(!nextProps.loading){
      const nextPropsWeek = nextProps.match.params.week;
      if( (this.props.match.params.week != nextPropsWeek)){
        this.getData(nextPropsWeek);
      }
      if (this.props.data !== nextProps.data) {
        this.mapData(nextProps);
      }
    }
  }
  getData(week){
    debugger;
    const weekNum = !week ? `${moment().week()}-${moment().year()}` : week;
    // const weekNum = !week ? '02-2018' : week;
    this.props.fetch(weekNum);
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
  debugger;

  return { data: state.week.comics, loading:state.week.loading, user: state.user };
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
  data: PropTypes.array,
  follow: PropTypes.func.isRequired,
  match: PropTypes.shape({
    params: PropTypes.shape({
      week: PropTypes.node,
    }).isRequired,
  }).isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(WeekPage);
