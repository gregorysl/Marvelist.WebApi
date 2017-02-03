import React, { PropTypes } from 'react';
import FollowIcon from './FollowIcon';
import ComicCount from './ComicCount';

const ActionsBar = (props) => {
    return (
        <div className="quick-icons">
            <div className="actions">
                <FollowIcon following={props.following} click={props.click} />
                <a href={props.url} target="blank">
                    <i className="fa fa-external-link"></i>
                </a>
            </div>
            <ComicCount count={props.comicCount} />
        </div>
    );
};

ActionsBar.propTypes = {
    comicCount: PropTypes.number,
    following: PropTypes.bool.isRequired,
    click: PropTypes.func.isRequired,
    url: PropTypes.string.isRequired
};

export default ActionsBar;