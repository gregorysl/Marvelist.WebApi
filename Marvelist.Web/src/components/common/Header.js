import React, { PropTypes } from "react";
import { connect } from "react-redux";
import { Link } from "react-router";
import { logout } from "../../actions/userActions";
import SearchBar from "./Search";
import { Menu, Input } from 'antd';


class HeaderMy extends React.Component {
  constructor(props) {
    super(props);
    this._logout = this._logout.bind(this);
  }

  _logout() {
    this.props.logout();
  }

  render() {
    let url = require("../../images/logo.svg");
    let navButtons = this.props.user.loggedIn
      ? (
        <Menu mode="horizontal"  >
          <Menu.Item><Link to="/dashboard" >{this.props.user.username}</Link></Menu.Item>
          <Menu.Item><a href="#"  onClick={this._logout}>Logout</a></Menu.Item>
        </Menu>
      )
      : (
        <Menu mode="horizontal" >
          <Menu.Item><Link to="/register">Register</Link></Menu.Item>
          <Menu.Item><Link to="/login">Login</Link></Menu.Item>
        </Menu>
      );
    return (
      <div style={{ display: 'flex' }}>
        
        <Menu  mode="horizontal" style={{ flex: '1' }} >
          <Menu.Item><Link to="/"><img className="logo" src={url} /></Link></Menu.Item>
          <Menu.Item><Link to="/series">Series</Link></Menu.Item>
          <Menu.Item><Link to="/about">About</Link></Menu.Item>
          <Menu.Item>
            <SearchBar />
          </Menu.Item>
        </Menu>
        {navButtons}
      </div>
    );
  }
}

const mapStateToProps = (state, ownProps) => {
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
