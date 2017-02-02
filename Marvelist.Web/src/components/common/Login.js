import React, { PropTypes } from "react";
import { Link } from "react-router";
import { connect } from "react-redux";
import { loginRequest } from "../../actions/userActions";
import Form from "./Form";

class Login extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        let {currentlySending, error} = this.props.data;


        return (
            <div className="form-page__wrapper">
                <div className="form-page__form-wrapper">
                    <div className="form-page__form-header">
                        <h2 className="form-page__form-heading">Login</h2>
                    </div>
                    <Form history={this.props.history} onSubmit={this.props.login} btnText={"Login"} error={error} currentlySending={currentlySending} />
                </div>
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