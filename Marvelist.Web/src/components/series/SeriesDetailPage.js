import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { fetchSeriesById, folllowComic, folllowSeries, readAllComic } from '../../actions/seriesActions';
import Card from '../card/Card';
import ReadAllButton from './ReadAllButton';
import FollowButton from './FollowButton';
import ProgressBar from './ProgressBar';
import { Row, Col } from 'antd';

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
        const details = this.props.seriesDetails;
        const comicList = details.comics.map((x, i) => <Card key={i} follow={follow} data={x} />);
        let percent = Math.round((details.read / details.comicCount) * 100 * 100) / 100;
        return (
            <div className="row">
                <Row type="flex" justify="center" style={{ 'paddingTop': '20px' }} >
                    <Col md={5} sm={24} style={{ height: '340px' }} >
                        <img style={{ height: '100%' }} src={details.thumbnail} alt="" />
                    </Col>
                    <Col md={3} sm={12} xs={24} >
                        <ProgressBar percent={percent} following={details.following} />
                    </Col>
                    <Col md={8} sm={12} >
                        <h2>{details.title}</h2>
                        <FollowButton following={details.following} click={folllowSeries} id={details.id} />
                        <ReadAllButton following={details.following} percent={percent} click={readAllComic} id={details.id} />
                        <p>{details.details}</p>

                    </Col>
                </Row>
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
        folllowSeries: seriesId => dispatch(folllowSeries(seriesId, true)),
        readAllComic: seriesId => dispatch(readAllComic(seriesId)),
        follow: (comicId, seriesId) => dispatch(folllowComic(comicId, false, seriesId))
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(SeriesDetails);