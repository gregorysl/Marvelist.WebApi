import React, { PropTypes } from "react";
import { Link } from "react-router";
import { connect } from "react-redux";
import { loginRequest } from "../../actions/userActions";

class Login extends React.Component {
    constructor(props) {
        super(props);
        this.state = { username: '', password: '' };
        this.handleChange = this.handleChange.bind(this);
        this._onSubmit = this._onSubmit.bind(this);
    }

    _onSubmit(event) {
        event.preventDefault();
        this.props.login(this.state.username, this.state.password);
    }
    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.id;

        this.setState({ [name]: value });
    }
    render() {
        return (
            <div>
                <form className="form-signin" onSubmit={this._onSubmit}>
                    <h2 className="form-signin-heading">Please login</h2>
                    <input type="text" className="form-control" id="username" value={this.state.username} onChange={this.handleChange} placeholder="Username" autoFocus="" />
                    <input type="password" className="form-control" id="password" value={this.state.password} onChange={this.handleChange} placeholder="Password" />
                    <button className="btn btn-lg btn-primary btn-block" type="submit">Login</button>
                </form>

            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        data: state.user
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        login: (username, password) => dispatch(loginRequest({ username, password }))
    };
};

Login.propTypes = {
    data: PropTypes.object.isRequired,
    login: PropTypes.func.isRequired
};


export default connect(mapStateToProps, mapDispatchToProps)(Login);