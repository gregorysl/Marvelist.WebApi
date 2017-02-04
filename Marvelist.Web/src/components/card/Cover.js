import React, { PropTypes } from 'react';
import Title from './Title';

const Cover = (props) => {
    const url = require("file-loader!../../images/not_found.png");
    return (
        <div className="cover">
            <img className="base" src={url} />
            <img className="real" src={`${props.thumbnail}`} />
            <div className="shadow-base"></div>
            <Title {...props} />
        </div>
    );
};

Cover.propTypes = {
    id: PropTypes.number,
    thumbnail: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired
};

export default Cover;