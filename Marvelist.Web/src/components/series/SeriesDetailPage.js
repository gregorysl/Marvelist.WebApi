import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { fetchSeriesById, folllowComic } from '../../actions/seriesActions';
import Card from '../card/Card';

class SeriesDetails extends React.Component {
    constructor(props) {
        super(props);
        this.hasComics = false;
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
        let {follow} = this.props;
        const comicList = this.hasComics ? this.props.seriesDetails.comics.map((x, i) => <Card key={i} follow={follow} data={x} />) : "";
        return (
            <div className="row">
                <div className="media">
                    <div className="media-left">
                        <img className="media-object" src={this.props.seriesDetails.thumbnail} alt="..." />
                    </div>
                    <div className="media-body">
                        <h2 className="media-heading">{this.props.seriesDetails.title}</h2>
                        {this.props.seriesDetails.details}
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
        follow: comicId => dispatch(folllowComic(comicId))
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(SeriesDetails);