import React, { PropTypes } from 'react';
import Cover from './Cover';
import ActionsBar from './ActionsBar';
import CoverDate from './CoverDate';

const Card = (props) => {
    return (
        <div className="series-card col-sm-3 col-xs-4">
            <Cover seriesLink={props.seriesLink} {...props.data} />
            {props.data.date && <CoverDate comicDate={props.data.date} />}
            <ActionsBar click={props.toggleFollow} {...props.data} />
        </div>
    );
};

Card.propTypes = {
    toggleFollow: PropTypes.func,
    seriesLink: PropTypes.bool,
    data: PropTypes.object.isRequired
};

export default Card;