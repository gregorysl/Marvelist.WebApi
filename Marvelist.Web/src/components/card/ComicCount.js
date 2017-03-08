import React, { PropTypes } from 'react';

const ComicCount = (props) => {
    if (!props.count) {
        return null;
    }
    return (
        <div className="metadata">
            {props.count}
            <i className="anticon anticon-book"/>
        </div>
    );
};
ComicCount.propTypes = {
    count: PropTypes.number
};

export default ComicCount;