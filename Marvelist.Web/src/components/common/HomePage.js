import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import Card from '../card/Card';
import { fetchHome, folllowComic } from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';

class HomePage extends React.Component {
  constructor(props) {
    super(props);
    this.data = "";
  }
  componentWillMount() {
    if (this.props.user.loggedIn) {
      this.props.fetch();
    }
    this.mapData(this.props);
  }
  componentWillReceiveProps(nextProps) {
    if (this.props.home !== nextProps.home) {
      this.mapData(nextProps);
    }
  }
  mapData(props) {
    let { follow } = props;
    this.data = props.home.map((b, i) => <Card key={i} follow={follow} data={b} place={PLACE.HOME} />);
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
  return { home: state.homeComics, user: state.user };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetch: () => dispatch(fetchHome()),
    follow: (id, seriesId) => dispatch(folllowComic(id, PLACE.HOME, seriesId))
  };
};

HomePage.propTypes = {
  user: PropTypes.object.isRequired,
  fetch: PropTypes.func.isRequired,
  home: PropTypes.array,
  follow: PropTypes.func.isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(HomePage);
