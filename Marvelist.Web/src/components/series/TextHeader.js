import React, { PropTypes } from 'react';

const TextHeader = (props) => {
    let text = !props.text ? "Series" : `Search results for "${props.text}"`;
    const showRaw = !props.raw ? text : props.raw;
    return (
        <h1>{showRaw}</h1>
    );
};

TextHeader.propTypes = {
    text: PropTypes.string,
    raw: PropTypes.string
};

export default TextHeader;