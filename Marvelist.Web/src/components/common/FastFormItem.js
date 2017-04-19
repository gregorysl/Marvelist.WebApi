import React, { PropTypes } from 'react';
import { Form, Icon, Input } from 'antd';
const FormItem = Form.Item;

const FastFormItem = (props) => {
    const additionalRules = props.rules || [];
    const req = { required: true, message: props.placeholder + ' is required!' };
    return (
        <FormItem>
            {props.decorator(props.name, { rules: [req, ...additionalRules] })(
                <Input addonBefore={<Icon type={props.icon} />}  type={props.type} placeholder={props.placeholder} />
            )}
        </FormItem>
    );
};

FastFormItem.propTypes = {
    icon: PropTypes.string,
    name: PropTypes.string.isRequired,
    type: PropTypes.string,
    rules: PropTypes.array,
    decorator: PropTypes.func.isRequired,
    placeholder: PropTypes.string.isRequired
};

export default FastFormItem;