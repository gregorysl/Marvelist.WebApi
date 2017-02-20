import React, { PropTypes } from 'react';

class ReadAllButton extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        debugger;
        this.props.click(this.props.id);
    }


    render() {
        const disabled = this.props.percent == 100 ? "btn disabled" : "btn ";
        return (
            <button onClick={this.handleClick} className={disabled}>Mark all as read</button>
        );
    }
};

ReadAllButton.propTypes = {
    percent: PropTypes.number.isRequired,
    click: PropTypes.func.isRequired,
    id: PropTypes.number.isRequired
};

export default ReadAllButton;