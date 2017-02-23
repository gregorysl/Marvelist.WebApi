import React, { PropTypes } from 'react';
import Cover from './Cover';
import ActionsBar from './ActionsBar';
import CoverDate from './CoverDate';

class Card extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
    }
    handleClick() {
        this.props.follow(this.props.data.id, this.props.data.seriesId);
    }
    render() {
        return (
            <div className="series-card col-sm-3 col-xs-4">
                <Cover link={this.props.link} {...this.props.data} />
                {this.props.data.date && <CoverDate comicDate={this.props.data.date} />}
                <ActionsBar click={this.handleClick} {...this.props.data} />
            </div>
        );
    }
}

Card.propTypes = {
    toggleFollow: PropTypes.func,
    follow: PropTypes.func.isRequired,
    link: PropTypes.number,
    data: PropTypes.object.isRequired
};

export default Card;