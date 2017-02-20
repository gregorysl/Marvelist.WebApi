import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Card from '../card/Card';
import TextHeader from './TextHeader';
import { fetchSeries, folllowSeries, search } from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';

class Series extends React.Component {
  constructor(props) {
    super(props);
    this.state = { showFollowed:false };
  }
  componentWillMount() {
    if (this.props.route.path === "/dashboard" || this.props.route.path === "/series") {
        this.props.fetch(this.props.route.path);
      }
      else if (this.props.params.text) {
        this.props.search(this.props.params.text);
      }
  }
  componentDidMount() {
  }

  componentWillReceiveProps(nextProps) {
    if (this.props.params != nextProps.params) {
      if (nextProps.route.path === "/dashboard" || nextProps.route.path === "/series") {
        nextProps.fetch(nextProps.route.path);
      }
      else if (nextProps.params.text) {
        nextProps.search(nextProps.params.text);
      }
    }
  }
  render() {
    let {follow} = this.props;
    //.filter(x=>this.state.showFollowed || x.following==this.state.showFollowed)
    const seriesList = this.props.series.map((b, i) => <Card key={i} follow={follow} data={b} link={PLACE.SERIES} />);
    return (
      <div className="row cards">
        <TextHeader text={this.props.params.text} />
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