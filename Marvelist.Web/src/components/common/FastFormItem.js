


import React, { PropTypes } from 'react';
import { Form, Icon, Input } from 'antd';
const FormItem = Form.Item;

const FastFormItem = (props) => {
    const { getFieldDecorator } = props.form;
    const req = { required: true, message: props.placeholder + ' is required!' };
    return (
        <FormItem>
            {getFieldDecorator(props.name, { rules: [req] })(
                <Input addonBefore={<Icon type={props.icon} />}  type={props.type} placeholder={props.placeholder} />
            )}
        </FormItem>
    );
};

FastFormItem.propTypes = {
    icon: PropTypes.string,
    name: PropTypes.string,
    type: PropTypes.string,
    placeholder: PropTypes.string
};

export default FastFormItem;