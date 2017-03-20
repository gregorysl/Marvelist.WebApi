import React, { PropTypes } from 'react';
import Cover from './Cover';
import ActionsBar from './ActionsBar';
import { Spin, Col, Card } from 'antd';

class MarvelistCard extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        this.props.follow(this.props.data.id, this.props.data.seriesId);
    }

    render() {
        return (
            <Col xs={12} sm={6} md={6} lg={4} >
                <Spin size="large" spinning={this.props.data.loading}>
                    <Card bordered={false} bodyStyle={{ padding: 0 }}>
                        <Cover link={this.props.link} {...this.props.data} />
                        <ActionsBar click={this.handleClick} {...this.props.data} />
                    </Card>
                </Spin>
            </Col>
        );
    }
}

MarvelistCard.propTypes = {
    toggleFollow: PropTypes.func,
    follow: PropTypes.func.isRequired,
    link: PropTypes.number,
    data: PropTypes.object.isRequired
};

export default MarvelistCard;