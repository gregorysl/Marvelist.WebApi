import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Card from '../card/Card';
import TextHeader from './TextHeader';
import { fetchSeries, folllowSeries, search } from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';

class Series extends React.Component {
  constructor(props) {
    super(props);
  }
  componentWillMount() {

    if (!this.props.params.text) {
      this.props.fetch();
    }
    else {
      this.props.search(this.props.params.text);
    }
  }
  componentDidMount() {
  }

  componentWillReceiveProps(nextProps) {
    if (this.props.params != nextProps.params) {
      if (!nextProps.params.text) {
        this.props.fetch();
      }
      else {
        nextProps.search(nextProps.params.text);
      }
    }
  }
  render() {
    let {follow} = this.props;
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
    fetch: () => dispatch(fetchSeries()),
    search: (text) => dispatch(search(text)),
    follow: (id) => dispatch(folllowSeries(id))
  };
};

Series.propTypes = {
  series: PropTypes.array.isRequired,
  fetch: PropTypes.func.isRequired,
  follow: PropTypes.func.isRequired,
  params: PropTypes.shape({ text: PropTypes.string }).isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(Series);