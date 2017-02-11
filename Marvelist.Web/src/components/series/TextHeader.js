import React, { PropTypes } from 'react';

const TextHeader = (props) => {
    let text = !props.text ? "Series" : `Search results for "${props.text}"`;
    return (
        <h3>{text}</h3>
    );
};

TextHeader.propTypes = {
    text: PropTypes.string
};

export default TextHeader;