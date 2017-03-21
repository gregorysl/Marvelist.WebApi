import React, { PropTypes } from 'react';
import Title from './Title';
import CoverDate from './CoverDate';

const Cover = (props) => {
    const url = require("file-loader!../../images/not_found.png");
    return (
        <div className="[ info-card ]">
            {props.date && <CoverDate comicDate={props.date} />}
            <img className="base" src={url} />
            <img src={props.thumbnail} />
            <div className="[ info-card-details ] animate">
                <Title link={props.link} {...props} />
                <p className="[ info-card-detail ]">{props.description}</p>
            </div>
        </div>
    );
};

Cover.propTypes = {
    id: PropTypes.number,
    date: PropTypes.string,
    thumbnail: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired,
    link: PropTypes.number
};

export default Cover;