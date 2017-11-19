import React from 'react';
import PropTypes from 'prop-types';

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