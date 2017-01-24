import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as seriesActions from '../../actions/seriesActions';

class SeriesDetails extends React.Component {
    constructor(props) {
        super(props);
    }
    componentDidMount() {
        this
            .props
            .fetchSeriesById(this.props.params.id);
    }
    render() {
        return (
            <div>
                <h1>{this.props.seriesDetails.title}</h1>
                <div className="media">
                    <div className="media-left">
                        <a href="#">
                            <img className="media-object" src={this.props.seriesDetails.thumbnail} alt="..."/>
                        </a>
                    </div>
                    <div className="media-body">
                        <h4 className="media-heading">Media heading</h4>
                        ...
                    </div>
                </div>
            </div>
        );
    }
}

SeriesDetails.propTypes = {
    seriesDetails: PropTypes.object.isRequired,
    fetchSeriesById: PropTypes.func,
    params: PropTypes
        .shape({id: PropTypes.number.isRequired})
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