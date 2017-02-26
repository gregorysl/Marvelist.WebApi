import React, { PropTypes } from 'react';
import Cover from './Cover';
import ActionsBar from './ActionsBar';
import CoverDate from './CoverDate';
import { Spin, Row, Col, Card } from 'antd';

class Card1 extends React.Component {
    constructor(props) {
        super(props);
        this.loading = !!props.loading;
        this.handleClick = this.handleClick.bind(this);
    }
    handleClick() {
        this.props.follow(this.props.data.id, this.props.data.seriesId);
    }
    render() {
        return (

            <Col className="series-card" xs={{ span: 8 }} sm={{ span: 6 }} lg={{ span: 4 }} >
                <Spin size="large" spinning={this.loading}>
                    <Card bodyStyle={{ padding: 0 }}>
                        <Cover link={this.props.link} {...this.props.data} />
                        {this.props.data.date && <CoverDate comicDate={this.props.data.date} />}
                        <ActionsBar click={this.handleClick} {...this.props.data} />
                    </Card>
                </Spin>
            </Col>
        );
    }
}

Card1.propTypes = {
    toggleFollow: PropTypes.func,
    follow: PropTypes.func.isRequired,
    link: PropTypes.number,
    data: PropTypes.object.isRequired
};

export default Card1;