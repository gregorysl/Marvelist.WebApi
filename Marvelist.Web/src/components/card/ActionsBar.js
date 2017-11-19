import React from 'react';
import PropTypes from 'prop-types';
import FollowIcon from './FollowIcon';
import UrlIcon from './UrlIcon';
import ComicCount from './ComicCount';

const ActionsBar = (props) => {
    if (props.following == null) {
        return null;
    }
    const barColor = `quick-icons ${props.following ? "" : "red"}`;
    return (
        <div className={barColor}>
            <FollowIcon following={props.following} click={props.click} />
            <UrlIcon url={props.url} />
            <ComicCount count={props.comicCount} />
        </div>
    );
};

ActionsBar.propTypes = {
    comicCount: PropTypes.number,
    following: PropTypes.bool,
    click: PropTypes.func.isRequired,
    url: PropTypes.string
};

export default ActionsBar;