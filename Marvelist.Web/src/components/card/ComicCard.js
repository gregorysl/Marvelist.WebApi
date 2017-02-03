import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import ActionsBar from './ActionsBar';

class ComicCard extends React.Component {
    constructor(props) {
        super(props);
        this.toggleFollow = this.toggleFollow.bind(this);
    }

    toggleFollow() {
        this.props.follow(this.props.comic.id);
    }
    render() {
        const url = require("file-loader!../../images/not_found.png");
        return (
            <div className="series-card col-sm-3 col-xs-4">
                <div className="cover">
                    <img className="base" src={url} />
                    <img className="real" src={`${this.props.comic.thumbnail}`} />
                    <div className="shadow-base"></div>
                    <div className="titles">
                        <h3>{this.props.comic.title}</h3>
                    </div>
                </div>
                <div className="date">
                    <span className="day">12</span>
                    <span className="month">Aug</span>
                    <span className="year">2016</span>
                </div>
                <ActionsBar click={this.toggleFollow} {...this.props.comic} />
            </div>
        );
    }
}
const mapStateToProps = (state, ownProps) => {
    return {};
};

const mapDispatchToProps = (dispatch) => {
    return {
        follow: (id) => null //dispatch(folllowSeries(id))
    };
};
ComicCard.propTypes = {
    comic: PropTypes.object.isRequired,
    follow: PropTypes.func.isRequired
};
export default connect(mapStateToProps, mapDispatchToProps)(ComicCard);