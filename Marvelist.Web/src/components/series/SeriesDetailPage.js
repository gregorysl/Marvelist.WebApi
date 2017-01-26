import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as seriesActions from '../../actions/seriesActions';
import ComicCard from '../card/ComicCard';

class SeriesDetails extends React.Component {
    constructor(props) {
        super(props);
        this.hasComics = false;
    }
    componentWillMount() {
        this
            .props
            .fetchSeriesById(this.props.params.id);
    }
    componentWillReceiveProps(nextProps){
        if(this.props.seriesDetails!==nextProps.seriesDetails){
            this.hasComics = true;
        }
    }
    render() {
        const comicList = this.hasComics ? this.props.seriesDetails.comics.map((x,i)=><ComicCard key={i} comic={x} />) : "";
        return (
            <div className="row"> 
                <div className="media">
                    <div className="media-left">
                            <img className="media-object" src={this.props.seriesDetails.thumbnail} alt="..."/>
                    </div>
                    <div className="media-body">
                        <h2 className="media-heading">{this.props.seriesDetails.title}</h2>
                        ...
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
    fetchSeriesById: PropTypes.func,
    params: PropTypes
        .shape({id: PropTypes.string.isRequired})
        .isRequired
};

const mapStateToProps = (state, ownProps) => {
    return {seriesDetails: state.seriesDetails};
};

const mapDispatchToProps = (dispatch) => {
    return {
        fetchSeriesById: seriesId => dispatch(seriesActions.fetchSeriesById(seriesId))
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(SeriesDetails);