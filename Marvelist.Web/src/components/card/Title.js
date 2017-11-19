import React from 'react';
import PropTypes from 'prop-types';
import { PLACE } from '../../actions/constants';

const Title = (props) => {
    let title = "";
    switch (props.place) {
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
        <h2 className="[ info-card-header ]" >
            {title}
        </h2>
    );
};

Title.propTypes = {
    place: PropTypes.number,
    id: PropTypes.number,
    seriesId: PropTypes.number,
    title: PropTypes.string.isRequired
};

export default Title;