import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as seriesActions from '../../actions/seriesActions';

class SeriesDetails extends React.Component {
    constructor(props, context) {
        super(props, context);
    }
    componentDidMount() {
        this.props.fetchSeriesById(this.props.params.id);
    }
    render() {
        return (
            <div>
                <h1>Series Details Page</h1>
            </div>
        );
    }
}

const mapStateToProps = (state, ownProps) => {
    return {serie: state.serie};
};

const mapDispatchToProps = (dispatch) => {
    return {
        fetchSeriesById: seriesId => dispatch(seriesActions.fetchSeriesById(seriesId))
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(SeriesDetails);