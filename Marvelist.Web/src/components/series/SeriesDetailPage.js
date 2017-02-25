import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { fetchSeriesById, folllowComic, folllowSeries, readAllComic } from '../../actions/seriesActions';
import Card from '../card/Card';
import ReadAllButton from './ReadAllButton';
import FollowButton from './FollowButton';
import ProgressBar from './ProgressBar';

class SeriesDetails extends React.Component {
    constructor(props) {
        super(props);
    }
    componentWillMount() {
        this.props.fetchById(this.props.params.id);
    }
    componentWillReceiveProps(nextProps) {
        if (this.props.seriesDetails !== nextProps.seriesDetails) {
            this.hasComics = true;
        }
    }
    render() {
        let {follow, folllowSeries, readAllComic} = this.props;
        const comicList = this.props.seriesDetails.comics.map((x, i) => <Card key={i} follow={follow} data={x} />);
        let percent = Math.round((this.props.seriesDetails.read / this.props.seriesDetails.comicCount) * 100* 100) / 100;
        return (
            <div className="row">
                <div className="media">
                    <div className="media-left">
                        <img className="media-object" src={this.props.seriesDetails.thumbnail} />
                    </div>
                    <div className="media-body">
                        <h2 className="media-heading">{this.props.seriesDetails.title}</h2>
                        {this.props.seriesDetails.details}
                        <ProgressBar percent={percent} following={this.props.seriesDetails.following} />
                        <FollowButton following={this.props.seriesDetails.following} click={folllowSeries} id={this.props.seriesDetails.id} />
                        <ReadAllButton following={this.props.seriesDetails.following} percent={percent} click={readAllComic} id={this.props.seriesDetails.id} />
                    </div>
                </div>
                <div className="row cards">
                    {comicList}
                </div>
            </div>
        );
    }
}

SeriesDetails.propTypes = {
    seriesDetails: PropTypes.object.isRequired,
    fetchById: PropTypes.func.isRequired,
    follow: PropTypes.func.isRequired,
    folllowSeries: PropTypes.func.isRequired,
    readAllComic: PropTypes.func.isRequired,
    params: PropTypes
        .shape({ id: PropTypes.string.isRequired })
        .isRequired
};

const mapStateToProps = (state, ownProps) => {
    return { seriesDetails: state.seriesDetails };
};

const mapDispatchToProps = (dispatch) => {
    return {
        fetchById: seriesId => dispatch(fetchSeriesById(seriesId)),
        folllowSeries: seriesId => dispatch(folllowSeries(seriesId)),
        readAllComic: seriesId => dispatch(readAllComic(seriesId)),
        follow: (comicId, seriesId) => dispatch(folllowComic(comicId, false, seriesId))
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(SeriesDetails);