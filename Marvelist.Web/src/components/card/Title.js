import React, { PropTypes } from 'react';

const Title = (props) => {
    const title = props.seriesLink ? (<a href={`/Series/${props.id}`}>{props.title}</a>) : (props.title);
    return (
        <div className="titles">
            <h3>
                {title}
            </h3>
        </div>
    );
};

Title.propTypes = {
    seriesLink: PropTypes.bool,
    id: PropTypes.number,
    title: PropTypes.string.isRequired
};

export default Title;