import React, { PropTypes } from 'react';
import Title from './card/Title';
import ActionsBar from './card/ActionsBar';
import { PLACE } from '../actions/constants';
import { Spin, Col, Row, Progress } from 'antd';

class DashboardItem extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        this.props.follow(this.props.data.id, this.props.data.seriesId);
    }

    render() {
        let percent = this.props.data.comicCount != 0 ? Math.round((this.props.data.read / this.props.data.comicCount) * 100 * 10) / 10 : 100;
        return (
            <Col md={12}>
                <Spin size="large" spinning={this.props.data.loading}>
                    <Col md={12} >
                        <img className="img-dashboard" src={this.props.data.thumbnail} />
                    </Col>
                    <Col md={12}>
                        <ActionsBar click={this.handleClick} {...this.props.data} />
                        <Row>
                            <Title place={PLACE.SERIES} id={this.props.data.id} title={this.props.data.title} />
                            <Progress type="circle" percent={percent} />
                        </Row>
                    </Col>
                </Spin>
            </Col>
        );
    }
}

DashboardItem.propTypes = {
    toggleFollow: PropTypes.func,
    dashboard: PropTypes.bool,
    follow: PropTypes.func.isRequired,
    place: PropTypes.number,
    data: PropTypes.object.isRequired
};

export default DashboardItem;