import React from 'react';
import {connect} from 'react-redux'
import {Link} from 'react-router';
import {logout} from '../../actions/userActions';

class Header extends React.Component {
  constructor(props) {
    super(props)
    this._logout = this
      ._logout
      .bind(this)
  }

  render() {
    let url = require("../../images/logo.svg");
    let navButtons = this.props.data.user.loggedIn
      ? (
            <ul className="nav navbar-nav">
        <li><Link to='/dashboard' className='btn btn--dash btn--nav'>{this.props.data.user.username}</Link></li>
        <li><a href='#' className='btn btn--login btn--nav' onClick={this._logout}>Logout</a></li>
        </ul>
      )
      : (
            <ul className="nav navbar-nav">
        <li><Link to='/register' className='btn btn--login btn--nav'>Register</Link></li>
        <li><Link to='/login' className='btn btn--login btn--nav'>Login</Link>
        </li>
        </ul>
      ) //TODO
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
                <Link to="/books">Book</Link>
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
  _logout() {
    this
      .props
      .dispatch(logout())
  }
}

function select(state) {
  return {data: state}
}

export default connect(select)(Header);
