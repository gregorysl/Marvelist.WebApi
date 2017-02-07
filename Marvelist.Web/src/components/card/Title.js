import React, { PropTypes } from 'react';

const Title = (props) => {
    let title = "";
    if (props.seriesLink) {
        title = (<a href={`/Series/${props.id}`}>{props.title}</a>);
    }
    else if (props.homeLink) {
        title = (<a href={`/Series/${props.seriesId}`}>{props.title}</a>);
    } else {
        title = (props.title);
    }

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
    homeLink: PropTypes.bool,
    id: PropTypes.number,
    seriesId: PropTypes.number,
    title: PropTypes.string.isRequired
};

export default Title;