import React, { PropTypes } from 'react';
import { PLACE } from '../../actions/constants';

const Title = (props) => {
    let title = "";
    switch (props.link) {
        case PLACE.HOME:
            title = (<a href={`/Series/${props.seriesId}`}>{props.title}</a>);
            break;
        case PLACE.SERIES:
            title = (<a href={`/Series/${props.id}`}>{props.title}</a>);
            break;
        default:
            title = (props.title);
            break;
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
    link: PropTypes.number,
    id: PropTypes.number,
    seriesId: PropTypes.number,
    title: PropTypes.string.isRequired
};

export default Title;