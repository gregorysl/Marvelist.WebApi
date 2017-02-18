import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Card from '../card/Card';
import { fetchHome, folllowComic } from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';

class HomePage extends React.Component {
  constructor(props) {
    super(props);
    this.hasData = false;
  }
  componentWillMount() {
    if (this.props.user.loggedIn) {
      this.props.fetch();
    }
  }
  componentWillReceiveProps(nextProps) {
    if (this.props.home !== nextProps.home) {
      this.hasData = true;
    }
  }

  render() {
    let {follow} = this.props;
    const comics = this.hasData ? this.props.home.map((b, i) => <Card key={i} follow={follow} data={b} link={PLACE.HOME} />) : "";
    return (
      <div className="row cards">
        {comics}
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
