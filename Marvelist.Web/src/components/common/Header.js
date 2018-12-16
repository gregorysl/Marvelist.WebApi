import React from 'react';
import PropTypes from 'prop-types';
import { connect } from "react-redux";
import { Link } from 'react-router-dom';
import history from "../../history";
import { logout } from "../../actions/userActions";
import { Menu, Input } from 'antd';
const Search = Input.Search;


class HeaderMy extends React.Component {
  constructor(props) {
    super(props);
    this._logout = this._logout.bind(this);
  }

  _logout() {
    this.props.logout();
  }
  onSearch(value) {
    history.push('/search/' + value);
  }

  render() {
    let url = require("../../images/logo.svg");
    let navButtons = this.props.user.loggedIn
      ? (
        <Menu mode="horizontal"  >
          <Menu.Item><Link to="/dashboard" >{this.props.user.username}</Link></Menu.Item>
          <Menu.Item><a href="#" onClick={this._logout}>Logout</a></Menu.Item>
        </Menu>
      )
      : (
        <Menu mode="horizontal" >
          <Menu.Item><Link to="/register">Register</Link></Menu.Item>
          <Menu.Item><Link to="/login">Login</Link></Menu.Item>
        </Menu>
      );
    return (
      <div style={{ display: 'flex', maxHeight: '50px' }}>
        <Link to="/"><img className="logo" src={url} /></Link>
        <Menu mode="horizontal" style={{ flex: '1' }} >
          <Menu.Item><Link to="/week">Weekly pull</Link></Menu.Item>
          <Menu.Item><Link to="/series">Series</Link></Menu.Item>
          <Menu.Item><Link to="/about">About</Link></Menu.Item>
          <Menu.Item><Search placeholder="Search" style={{ width: 200 }} onSearch={this.onSearch} /></Menu.Item>
        </Menu>
        {navButtons}
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return { user: state.user };
};

const mapDispatchToProps = (dispatch) => {
  return {
    logout: () => dispatch(logout())
  };
};

HeaderMy.propTypes = {
  user: PropTypes.object.isRequired,
  logout: PropTypes.func.isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(HeaderMy);
