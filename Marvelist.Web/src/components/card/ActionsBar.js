import React, { PropTypes } from 'react';
import FollowIcon from './FollowIcon';
import ComicCount from './ComicCount';

const ActionsBar = (props) => {
    const barColor = `quick-icons ${props.following ? "" : "red"}`;
    return (
        <div className={barColor}>
            <div className="actions">
                <FollowIcon following={props.following} click={props.click} />
                <a href={props.url} target="blank">
                    <i className="anticon anticon-link"/>
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