import React, { PropTypes } from 'react';
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
  }
  componentWillReceiveProps(nextProps) {
    if (this.props.home !== nextProps.home) {
      let { follow } = nextProps;
      this.data = nextProps.home.map((b, i) => <Card key={i} follow={follow} data={b} link={PLACE.HOME} />);
    }
  }

  render() {
    return (
      <div className="row cards">
        {this.data}
      </div>
    );
  }
}
const mapStateToProps = (state, ownProps) => {
  return { home: state.homeComics, user: state.user };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetch: () => dispatch(fetchHome()),
    follow: (id) => dispatch(folllowComic(id, true))
  };
};

HomePage.propTypes = {
  user: PropTypes.object.isRequired,
  fetch: PropTypes.func.isRequired,
  home: PropTypes.array,
  follow: PropTypes.func.isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(HomePage);
