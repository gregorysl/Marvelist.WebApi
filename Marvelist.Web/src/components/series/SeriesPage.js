import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Card from '../card/Card';
import TextHeader from './TextHeader';
import { fetchSeries, folllowSeries, search } from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';
import { Switch, Icon, Pagination } from 'antd';

class Series extends React.Component {
  constructor(props) {
    super(props);
    this.mapData = this.mapData.bind(this);
    this.filterBoxChange = this.filterBoxChange.bind(this);
    //todo move to store
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
      this.data = this.mapData(nextProps, this.state.showFollowed);
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

  filterBoxChange(checked) {
    this.setState({ showFollowed: checked });
    this.data = this.mapData(this.props, checked);
  }

  mapData(props, showFollowed) {
    const series = showFollowed ? props.series : props.series.filter(x => !x.following);
    return series.map((b, i) => <Card key={i} follow={props.follow} data={b} link={PLACE.SERIES} />);
  }

  render() {
    return (
      <div>
        <div className="row">
          <TextHeader text={this.props.params.text} />
          <p><Switch checkedChildren={"Show"} unCheckedChildren={"Hide"} onChange={this.filterBoxChange} defaultChecked /> following series </p>
          <Pagination  defaultPageSize={50} />
        </div>
        <div className="row cards">
          {this.data}
        </div>
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