import React, { PropTypes } from 'react';

const FollowIcon = (props) => {
    const classFollowing = `fa fa-heart${props.following ? "" : "-o"}`;
    return (
        <a>
            <i className={classFollowing} onClick={props.click}></i>
        </a>
    );
};

FollowIcon.propTypes = {
    click: PropTypes.func.isRequired,
    following: PropTypes.bool.isRequired
};

export default FollowIcon;