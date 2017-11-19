import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import DashboardItem from '../DashboardItem';
import TextHeader from './TextHeader';
import * as actions from '../../actions/seriesActions';
import { PLACE } from '../../actions/constants';
import { browserHistory } from "react-router";
import { Row } from 'antd';
import Pager from "../common/Pager";

class Dashboard extends React.Component {
    constructor(props) {
        super(props);
        this.mapData = this.mapData.bind(this);
        this.onChangePage = this.onChangePage.bind(this);
        this.data = "";
    }

    componentWillMount() {
        this.getData(this.props);
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.location.query != nextProps.location.query) {
            this.getData(nextProps);
        }
        else if (this.props.params != nextProps.params) {
            this.getData(nextProps);
        }
        this.data = this.mapData(nextProps);
    }

    getData(props) {
        let pageId = 0;
        if (props.location.query.page) {
            pageId = props.location.query.page - 1;
        }
        props.fetch("/dashboard", pageId);
    }

    mapData(props) {
        return props.series.map((b, i) => <DashboardItem key={i} follow={props.follow} data={b} place={PLACE.SERIES} dashboard />);
    }

    onChangePage(page) {
        let url = this.props.location.pathname + '?page=' + page;
        browserHistory.push(url);
    }

    render() {
        return (
            <div>
                <Row>
                    <TextHeader raw={"Dashboard"} />
                    <Pager pageData={this.props.pageData} onChangePage={this.onChangePage} />
                </Row>
                <Row>
                    {this.data}
                </Row>
                <Row>
                    <Pager pageData={this.props.pageData} onChangePage={this.onChangePage} />
                </Row>
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        filters: state.series.filters,
        series: state.series.series,
        pageData: state.series.pageData
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        followedFilter: (show) => dispatch(actions.setFollowedFilter(show)),
        fetch: (text, page) => dispatch(actions.fetchSeries(text, page)),
        search: (text, page) => dispatch(actions.search(text, page)),
        follow: (id) => dispatch(actions.folllowSeries(id))
    };
};

Dashboard.propTypes = {
    fetch: PropTypes.func.isRequired,
    follow: PropTypes.func.isRequired,
    search: PropTypes.func.isRequired,
    followedFilter: PropTypes.func.isRequired,
    series: PropTypes.array,
    pageData: PropTypes.object,
    filters: PropTypes.object,
    params: PropTypes.shape({ text: PropTypes.string }).isRequired,
    route: PropTypes.shape({ path: PropTypes.string }).isRequired,
    location: React.PropTypes.object
};

export default connect(mapStateToProps, mapDispatchToProps)(Dashboard);