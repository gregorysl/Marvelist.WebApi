import React, { PropTypes } from "react";
import { connect } from "react-redux";
import { loginRequest } from "../../actions/userActions";
import { Form, Icon, Input, Button } from 'antd';
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
        const { getFieldDecorator } = this.props.form;
        return (
            <Form onSubmit={this.handleSubmit} className="login-form">
                <FormItem>
                    {getFieldDecorator('email', {
                        rules: [{
                            type: 'email', message: 'The input is not valid E-mail!'
                        }, { required: true, message: 'Please input your E-mail!', }]
                    })(
                        <Input addonBefore={<Icon type="mail" />} placeholder="E-mail" />
                        )}
                </FormItem>
                <FormItem>
                    {getFieldDecorator('username', { rules: [{ required: true, message: 'Username is required!' }] })(
                        <Input addonBefore={<Icon type="user" />} placeholder="Username" />
                    )}
                </FormItem>
                <FormItem>
                    {getFieldDecorator('password', { rules: [{ required: true, message: 'Please input your Password!' }] })(
                        <Input addonBefore={<Icon type="lock" />} type="password" placeholder="Password" />
                    )}
                </FormItem>
                <FormItem>
                    {getFieldDecorator('confirm', {
                        rules: [{ required: true, message: 'Please confirm your password!' }, {
                            validator: this.checkPassword,
                        }]
                    })(
                        <Input addonBefore={<Icon type="lock" />} type="password" placeholder="Password confirmation" />
                        )}
                </FormItem>
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