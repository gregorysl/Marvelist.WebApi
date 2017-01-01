import React, { Component } from 'react';
import LoginForm from './LoginForm';
import { connect } from 'react-redux';
import { push } from 'react-router-redux';
import { Link } from 'react-router';

class LoginPage extends Component {
  render() {
    return (
      <div>
        <h2>Login</h2>
        <hr />
        <LoginForm />
        <p>
          <Link to="/register">Register as a new user?</Link>
        </p>
        <p>
          <Link to="/forgotpassword">Forgot your password?</Link>
        </p>
      </div>
    );
  }
}

export default connect(
state => ({ user: "asd", externalLogin: "state.externalLogin" }),
{ pushState: push}
)(LoginPage);