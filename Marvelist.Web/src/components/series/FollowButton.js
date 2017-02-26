import React, { PropTypes } from 'react';
import { Button } from 'antd';

class FollowButton extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        this.props.click(this.props.id, true);
    }

    render() {
        const text = this.props.following ? "Following" : "Follow";
        return (
            <Button type="primary" onClick={this.handleClick}>{text}</Button>
        );
    }
}

FollowButton.propTypes = {
    following: PropTypes.bool.isRequired,
    click: PropTypes.func.isRequired,
    id: PropTypes.number.isRequired
};

export default FollowButton;