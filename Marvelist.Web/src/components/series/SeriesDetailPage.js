import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { fetchSeriesById, folllowComic, folllowSeries, readAllComic } from '../../actions/seriesActions';
import Card from '../card/Card';
import DetailsHeader from './DetailsHeader';

class SeriesDetails extends React.Component {
    constructor(props) {
        super(props);
        this.data = "";
    }
    componentWillMount() {
        this.props.fetchById(this.props.params.id);
    }
    componentWillReceiveProps(nextProps) {
        if (this.props.seriesDetails !== nextProps.seriesDetails) {
            this.data = nextProps.seriesDetails.comics.map((x, i) => <Card key={i} follow={nextProps.follow} data={x} />);
        }
    }
    render() {
        let { folllowSeries, readAllComic, seriesDetails } = this.props;
        return (
            <div className="row">
                <DetailsHeader details={seriesDetails} folllowSeries={folllowSeries} readAllComic={readAllComic} />
                <div className="row cards">
                    {this.data}
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

const mapStateToProps = (state) => {
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