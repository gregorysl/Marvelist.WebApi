import React, { PropTypes } from 'react';

const ProgressBar = (props) => {
    return (
        <div className="progress">
            <div className="progress-bar progress-bar-new" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style={{ width: props.percent + "%" }}>
                <span>{props.percent}%</span>
            </div>
        </div>
    );
};

ProgressBar.propTypes = {
    percent: PropTypes.number.isRequired
};

export default ProgressBar;