import React, { PropTypes } from 'react';
import Cover from './Cover';
import ActionsBar from './ActionsBar';
import CoverDate from './CoverDate';
import { Spin, Col, Card } from 'antd';
import Title from './Title';

class MarvelistCard extends React.Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        this.props.follow(this.props.data.id, this.props.data.seriesId);
    }

    render() {
        const url = require("../../images/not_found.png");
        return (

            <Col xs={12} sm={6} md={6} lg={4} >
                <Spin size="large" spinning={this.props.data.loading}>
                <Card bordered={false} bodyStyle={{ padding: 0}}>
                    <div className="[ info-card ]">
                        {this.props.data.date && <CoverDate comicDate={this.props.data.date} />}
                        <img className="base" src={url} />
                        <img src={this.props.data.thumbnail} />
                        <div className="[ info-card-details ] animate">
                            <div className="[ info-card-header ]">
                                <Title link={this.props.link} {...this.props.data} />
                            </div>
                            <div className="[ info-card-detail ]">
                                <p>{this.props.data.description}</p>
                            </div>
                        </div>
                    </div>

                    <ActionsBar click={this.handleClick} {...this.props.data} /></Card>
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