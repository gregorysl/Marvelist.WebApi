import React, { PropTypes } from "react";
import { Link } from "react-router";
import { connect } from "react-redux";
import { loginRequest } from "../../actions/userActions";
import { Form, Icon, Input, Button, Checkbox } from 'antd';
const FormItem = Form.Item;

class Login extends React.Component {
    constructor(props) {
        super(props);
        this.state = { username: '', password: '' };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        this.props.form.validateFields((err, values) => {
            if (!err) {
                this.props.login(this.state.username, this.state.password);
            }
        });
    }
    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.id;

        this.setState({ [name]: value });
    }
    render() {
        const { getFieldDecorator } = this.props.form;
        return (
            <Form onSubmit={this.handleSubmit} className="login-form">
                <FormItem>
                    {getFieldDecorator('username', {
                        rules: [{ required: true, message: 'Please input your username!' }]
                    })(
                        <Input addonBefore={<Icon type="user" />} placeholder="Username" onChange={this.handleChange} />
                        )}
                </FormItem>
                <FormItem>
                    {getFieldDecorator('password', {
                        rules: [{ required: true, message: 'Please input your Password!' }]
                    })(
                        <Input addonBefore={<Icon type="lock" />} type="password" placeholder="Password" onChange={this.handleChange} />
                        )}
                </FormItem>
                <FormItem>
                    <a className="login-form-forgot">Forgot password</a>
                    <Button type="primary" htmlType="submit" className="login-form-button">
                        Log in
          </Button>
                    Or <a>register now!</a>
                </FormItem>
            </Form>

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

const WrappedNormalLoginForm = Form.create()(connect(mapStateToProps, mapDispatchToProps)(Login));


export default WrappedNormalLoginForm;