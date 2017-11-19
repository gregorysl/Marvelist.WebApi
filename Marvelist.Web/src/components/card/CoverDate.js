import React from 'react';
import PropTypes from 'prop-types';

const months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

const CoverDate = (props) => {
    const day = new Date(props.comicDate).getDate();
    const monthId = new Date(props.comicDate).getMonth();
    const month = months[monthId];
    const year = new Date(props.comicDate).getFullYear();
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