


import React, { PropTypes } from 'react';
import { Form, Icon, Input } from 'antd';
const FormItem = Form.Item;

const FastFormItem = (props) => {
    const { getFieldDecorator } = props.form;
    return (
        <FormItem>
            {getFieldDecorator(props.name, { rules: [{ required: true, message: props.placeholder +' is required!' }] })(
                <Input addonBefore={<Icon type="user" />} placeholder={props.placeholder} />
            )}
        </FormItem>
    );
};

FastFormItem.propTypes = {
    name: PropTypes.string,
    placeholder: PropTypes.string
};

export default FastFormItem;