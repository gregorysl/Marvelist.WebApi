import React, { PropTypes } from 'react';

class FollowButton extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        this.props.click(this.props.id);
    }

    render() {
        const text = this.props.following ? "Following" : "Follow";
        return (
            <button className="btn " onClick={this.handleClick} >{text}</button>
        );
    }
};

FollowButton.propTypes = {
    following: PropTypes.bool.isRequired,
    click: PropTypes.func.isRequired,
    id: PropTypes.number.isRequired
};

export default FollowButton;