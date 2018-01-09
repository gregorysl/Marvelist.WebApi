import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';

const CoverDate = (props) => {
    const date = moment(props.comicDate);
    const day = date.date();
    const month = date.format('MMM');
    const year = date.year();
    return (
        <div className="date">
            <span className="day">{day}</span>
            <span className="month">{month}</span>
            <span className="year">{year}</span>
        </div>
    );
};

CoverDate.propTypes = {
    comicDate: PropTypes.string
};

export default CoverDate;