import React, {PropTypes} from "react";
import {connect} from "react-redux";
import {Link} from "react-router";
import {logout} from "../../actions/userActions";

class Header extends React.Component {
  constructor(props) {
    super(props);
    this._logout = this
      ._logout
      .bind(this);
  }

  _logout() {
    this.props.logout();
  }
  
  render() {
    let url = require("../../images/logo.svg");
    let navButtons = this.props.user.loggedIn
      ? (
        <ul className="nav navbar-nav">
          <li>
            <Link to="/dashboard" className="btn btn--dash btn--nav">{this.props.user.username}</Link>
          </li>
          <li>
            <a href="#" className="btn btn--login btn--nav" onClick={this._logout}>Logout</a>
          </li>
        </ul>
      )
      : (
        <ul className="nav navbar-nav">
          <li>
            <Link to="/register" className="btn btn--login btn--nav">Register</Link>
          </li>
          <li>
            <Link to="/login" className="btn btn--login btn--nav">Login</Link>
          </li>
        </ul>
      );
    return (
      <div className="navbar navbar-inverse navbar-fixed-top navbar-marvel">
        <div className="container">
          <div className="navbar-header">
            <button
              type="button"
              className="navbar-toggle"
              data-toggle="collapse"
              data-target=".navbar-collapse">
              <span className="icon-bar"></span>
              <span className="icon-bar"></span>
              <span className="icon-bar"></span>
            </button>
            <a href="/"><img className="logo" src ={url}/></a>
          </div>
          <div className="navbar-collapse collapse">
            <ul className="nav navbar-nav">
              <li>
                <Link to="/about">About</Link>
              </li>
              <li>
                <Link to="/series">Series</Link>
              </li>
              {navButtons}
            </ul>

          </div>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state, ownProps) => {
  return {user: state.user};
};

const mapDispatchToProps = (dispatch) => {
  return {
    logout: () => dispatch(logout())
  };
};

Header.propTypes = {
  user: PropTypes.object.isRequired,
  logout: PropTypes.func.isRequired
};

export default connect(mapStateToProps,mapDispatchToProps)(Header);
