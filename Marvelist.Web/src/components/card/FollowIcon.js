import React, { PropTypes } from 'react';

const FollowIcon = (props) => {
    if (props.following == null) {
        return null;
    }
    const classFollowing = `anticon anticon-check-square${props.following ? "" : "-o"}`;
    return (
        <a><i className={classFollowing} onClick={props.click} /></a>
    );
};

FollowIcon.propTypes = {
    click: PropTypes.func.isRequired,
    following: PropTypes.bool
};

export default FollowIcon;