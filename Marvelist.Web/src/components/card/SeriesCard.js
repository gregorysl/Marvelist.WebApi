import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { folllowSeries } from '../../actions/seriesActions';
import FollowIcon from './FollowIcon';
import ActionsBar from './ActionsBar';

class SeriesCard extends React.Component {
    constructor(props) {
        super(props);
        this.toggleFollow = this.toggleFollow.bind(this);
    }

    toggleFollow() {
        this.props.follow(this.props.series.id);
    }
    render() {
        const url = require("file-loader!../../images/not_found.png");
        return (
            <div className="series-card col-sm-3 col-xs-4">
                <div className="cover">
                    <img className="base" src={url} />
                    <img className="real" src={`${this.props.series.thumbnail}`} />
                    <div className="shadow-base"></div>
                    <div className="titles">
                        <h3>
                            <a href={`/Series/${this.props.series.id}`}>{this.props.series.title}</a>
                        </h3>
                    </div>
                </div>
                <ActionsBar click={this.toggleFollow} {...this.props.series} />

            </div>
        );
    }
}

const mapStateToProps = (state, ownProps) => {
    return {};
};

const mapDispatchToProps = (dispatch) => {
    return {
        follow: (id) => dispatch(folllowSeries(id))
    };
};

SeriesCard.propTypes = {
    series: PropTypes.object.isRequired,
    follow: PropTypes.func.isRequired
};
export default connect(mapStateToProps, mapDispatchToProps)(SeriesCard);