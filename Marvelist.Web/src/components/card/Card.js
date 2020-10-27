import React from "react";
import PropTypes from "prop-types";
import Cover from "./Cover";
import ActionsBar from "./ActionsBar";
import { Spin, Col, Card, Progress } from "antd";

class MarvelistCard extends React.Component {
  constructor(props) {
    super(props);
    this.handleClick = this.handleClick.bind(this);
  }

  handleClick() {
    const {
      props: { week, data, follow },
    } = this;
    if (week) {
      follow(data.id, data.seriesId, week);
    } else {
      follow(data.id, data.seriesId);
    }
  }

  render() {
    let percent =
      this.props.data.comicCount !== 0
        ? Math.round(
            (this.props.data.read / this.props.data.comicCount) * 100 * 10
          ) / 10
        : 100;
    return (
      <Col xs={12} sm={6} md={6} lg={4} xl={2}>
        <Spin size="large" spinning={this.props.data.loading}>
          <Card bordered={false} bodyStyle={{ padding: 0 }}>
            {this.props.dashboard && <Progress percent={percent} />}
            <Cover place={this.props.place} {...this.props.data} />
            <ActionsBar click={this.handleClick} {...this.props.data} />
          </Card>
        </Spin>
      </Col>
    );
  }
}

MarvelistCard.propTypes = {
  toggleFollow: PropTypes.func,
  dashboard: PropTypes.bool,
  follow: PropTypes.func.isRequired,
  place: PropTypes.number,
  data: PropTypes.object.isRequired,
};

export default MarvelistCard;
