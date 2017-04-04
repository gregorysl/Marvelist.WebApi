import React, { PropTypes } from 'react';

const UrlIcon = (props) => {
    if (!props.url) {
        return null;
    }
    return (
        <a href={props.url} target="blank">
            <i className="anticon anticon-link" />
        </a>
    );
};

UrlIcon.propTypes = {
    url: PropTypes.string
};

export default UrlIcon;