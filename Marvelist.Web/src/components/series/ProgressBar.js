import React, { PropTypes } from 'react';
import { Progress } from 'antd';

const ProgressBar = (props) => {
    if (!props.following) return null;
    return (
        <Progress trailColor='black' type="circle" percent={props.percent} />
    );
};

ProgressBar.propTypes = {
    percent: PropTypes.number.isRequired,
    following: PropTypes.bool.isRequired
};

export default ProgressBar;