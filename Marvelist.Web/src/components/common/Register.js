import React, { PropTypes } from "react";
import { connect } from "react-redux";
import { registerRequest } from "../../actions/userActions";
import { Form, Button } from 'antd';
import FastFormItem from './FastFormItem';
const FormItem = Form.Item;
const emailRule = [{ type: 'email', message: 'The input is not valid E-mail!' }];

class Register extends React.Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.checkPassword = this.checkPassword.bind(this);
    }

    checkPassword(rule, value, callback) {
        const form = this.props.form;
        if (value && value !== form.getFieldValue('password')) {
            callback('These passwords don\'t match.');
        } else {
            callback();
        }
    }

    handleSubmit(event) {
        event.preventDefault();
        this.props.form.validateFields((err, values) => {
            if (!err) {
                this.props.login(values.username, values.password);
            }
            if (err) return;

            this.props.register(values.email, values.username, values.password);
        });
    }
    render() {
        const arr = [{ type: 'email', message: 'The input is not valid E-mail!' }];
        const { getFieldDecorator } = this.props.form;
        return (
            <Form onSubmit={this.handleSubmit} className="login-form">
                <FastFormItem placeholder="E-mail" name="email" decorator={getFieldDecorator} icon="mail" rules={emailRule} />
                <FastFormItem placeholder="Username" name="username" decorator={getFieldDecorator} icon="user" />
                <FastFormItem placeholder="Password" name="password" decorator={getFieldDecorator} icon="lock" type="password" />
                <FastFormItem placeholder="Confirm Password" name="confirm" decorator={getFieldDecorator} icon="lock" type="password" rules={[{ validator: this.checkPassword }]} />
                <FormItem>
                    <Button type="primary" htmlType="submit" className="login-form-button">Register</Button>
                </FormItem>
            </Form>

        );
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        register: (email, username, password) => dispatch(registerRequest({ email, username, password }))
    };
};

Register.propTypes = {
    data: PropTypes.object.isRequired,
    login: PropTypes.func.isRequired,
    register: PropTypes.func.isRequired,
    form: PropTypes.object.isRequired
};

const WrappedNormalLoginForm = Form.create()(connect(null, mapDispatchToProps)(Register));


export default WrappedNormalLoginForm;