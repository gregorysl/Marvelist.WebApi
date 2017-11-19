import React from 'react';
import PropTypes from 'prop-types';
import { Button } from 'antd';

class ReadAllButton extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        this.props.click(this.props.id);
    }

    render() {
        if (!this.props.following) return null;
        const disabled = this.props.percent == 100;
        return (
            <Button type="primary" onClick={this.handleClick} disabled={disabled}>Mark all as read</Button>
        );
    }
}

ReadAllButton.propTypes = {
    percent: PropTypes.number.isRequired,
    click: PropTypes.func.isRequired,
    id: PropTypes.number.isRequired,
    following: PropTypes.bool.isRequired
};

export default ReadAllButton;