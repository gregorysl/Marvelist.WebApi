import React, { PropTypes } from 'react';
import Title from './card/Title';
import ActionsBar from './card/ActionsBar';
import { Spin, Col, Row, Card, Progress } from 'antd';

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
            <Col md={8}>

                <Col md={12} >
                    <img className="img-dashboard" src={this.props.data.thumbnail} />
                </Col>
                <Col md={12}>
                    <ActionsBar click={this.handleClick} {...this.props.data} />
                    <Title place={this.props.data.place} {...this.props.data} />
                    <Progress percent={percent}   />
                    <Spin size="large" spinning={this.props.data.loading}>
                        <Card bordered={false} bodyStyle={{ padding: 0 }}>

                            <div className="[ info-card-details ] animate">
                            </div>

                        </Card>
                    </Spin>
                </Col>
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