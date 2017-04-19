import React, { PropTypes } from "react";
import { connect } from "react-redux";
import { loginRequest } from "../../actions/userActions";
import { Form, Icon, Input, Button } from 'antd';
import FastFormItem from './FastFormItem';
const FormItem = Form.Item;

class Register extends React.Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        this.props.form.validateFields((err, values) => {
            if (!err) {
                this.props.login(values.username, values.password);
            }
        });
    }
    render() {
        const arr = [{ type: 'email', message: 'The input is not valid E-mail!' }];
        const { getFieldDecorator } = this.props.form;
        return (
            <Form onSubmit={this.handleSubmit} className="login-form">
                <FastFormItem placeholder="E-mail" name="email" decorator={getFieldDecorator} icon="mail" rules={arr} />
                <FastFormItem placeholder="Username" name="username" decorator={getFieldDecorator} icon="user" />
                <FastFormItem placeholder="Password" name="password" decorator={getFieldDecorator} icon="lock" type="password" />
                <FastFormItem placeholder="Confirm Password" name="confirm" decorator={getFieldDecorator} icon="lock" type="password" />
                <FormItem>
                    <Button type="primary" htmlType="submit" className="login-form-button">Log in</Button>
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

Register.propTypes = {
    data: PropTypes.object.isRequired,
    login: PropTypes.func.isRequired,
    form: PropTypes.object.isRequired
};

const WrappedNormalLoginForm = Form.create()(connect(mapStateToProps, mapDispatchToProps)(Register));


export default WrappedNormalLoginForm;